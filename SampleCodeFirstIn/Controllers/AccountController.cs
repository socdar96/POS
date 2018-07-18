using SampleCodeFirstIn.Context;
using SampleCodeFirstIn.Models;
using SampleCodeFirstIn.Class;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleCodeFirstIn.Controllers
{
    public class AccountController : Controller
    {
        InviContext db = new InviContext();
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            if (Session["username"] != null & Session["userid"] != null)
            {
                //Session["userid"] = null;
                return Redirect("~/Home");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
        }
        //Login
        //returns  0 - invalid user or pass / 1 - valid user or pass / 2 - lock user status
        public int validateUser(String _UserName, String _Password) 
        {
            try
            {
                User user = db.Users.Single(p => p.userName == _UserName);
                string truePassword = getTruePassword(user.Pwd);
                if (truePassword == _Password && user.disabled == false)
                {
                    int empID = user.userId;
                    Session["userid"] = empID;
                    Session["username"] = _UserName;
                    Session.Timeout = 15;
                    return 1;
                }
                else if (truePassword == _Password && user.disabled == true)
                {
                    return 2;
                }
                else if (truePassword != _Password)
                {
                    return 3;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            return 0; // return 0 to notify invalid input
        }
        public ActionResult LogOff()
        {
            Session["userid"] = null;
            Session["username"] = null;
            HttpContext.Session.Clear();
            HttpContext.Session.Abandon();
            HttpContext.Session.RemoveAll();
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = validateUser(model.Username, model.Password);
            switch (result)
            {
                case 1:
                    return RedirectToLocal(returnUrl);
                //case SignInStatus.RequiresVerification:
                //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case 2:
                    ModelState.AddModelError("", "User Disabled");
                    return View(model);
                case 3:
                    ModelState.AddModelError("", "Incorrect Password");
                    return View(model);
                case 0:
                default:
                    ModelState.AddModelError("", "Invalid Username");
                    return View(model);
            }
        }

        public JsonResult IsUserNameExist(string userName)
        {
            bool isExist = db.Users.Where(m => m.userName.ToLower().Equals(userName.ToLower())).FirstOrDefault() != null;
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }
        public String decryptPassword(int userid)
        {
            String recoveredpassword = "";
            User user = db.Users.Single(p => p.userId == userid);
            string oldpass = user.Pwd;
            try
            {
                recoveredpassword = MD5Crypt.Decrypt(oldpass, "admin", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                user.Pwd = MD5Crypt.Encrypt(user.Pwd, "admin", true);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return recoveredpassword;
        }
        public int saveNewPassword(int userid, String newPassword)
        {
            int success = 0;
            User user = db.Users.Single(p => p.userId == userid);
            user.Pwd = MD5Crypt.Encrypt(newPassword, "admin", true);

            //string recipient = "soc.alcantara.delonix.com.au";
            try
            {
                success = db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //new HRIS_WEB.Controllers.TimecardController().sendMail(recipient, null, "Password Reset.", mailbody.ToString());
            return success;
        }
        public String getTruePassword(String password)
        {
            return MD5Crypt.Decrypt(@password, "admin", true);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Main", "Home");
        }

        
    }
}
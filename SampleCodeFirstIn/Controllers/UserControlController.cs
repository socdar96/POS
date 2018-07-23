using SampleCodeFirstIn.Context;
using SampleCodeFirstIn.Models;
using SampleCodeFirstIn.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleCodeFirstIn.Controllers
{
    public class UserControlController : BaseController
    {
        InviContext db = new InviContext();
        // GET: UserControl
        public ActionResult UserList()
        {
            return View();
        }
        public JsonResult GetUsersList()
        {
            return Json(db.Users.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUserDetails(int id)
        {
            User x = db.Users.SingleOrDefault(p => p.userId == id);

            return Json(x, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertUser([Bind(Exclude = "userId")]User nUser)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    userName = nUser.userName,
                    emailAdd = nUser.emailAdd,
                    FirstName = nUser.FirstName,
                    SurName = nUser.SurName,
                    mobileNo = nUser.mobileNo,
                    disabled = nUser.disabled,
                    Pwd = MD5Crypt.Encrypt(nUser.Pwd, "admin", true),
                    shiftid = nUser.shiftid
                };
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();

                        return Json(new { isError = "F", message = "New user has been added!" });

                        //return Json(new { isError = "T", message = "Email address already exist." });
                }
                catch (Exception ex)
                {
                    return Json(new { isError = "T", message = "Could not insert data." });
                }
            }
            else
            {
                return Json(new { isError = "T", message = "Could not insert data." });
            }
        }
        public JsonResult DisEnableUser(int UserID, bool status)
        {
            if (ModelState.IsValid)
            {
                User newUser = db.Users.SingleOrDefault(p => p.userId == UserID);
                newUser.disabled = !status;
                try
                {
                    db.SaveChanges();
                    return Json(new { isError = "F", message = "New user has been added!" });
                }
                catch (Exception ex)
                {
                    return Json(new { isError = "T", message = "Could not insert data." });
                }
            }
            else
            {
                return Json(new { isError = "T", message = "Could not insert data." });
            }
        }
        public int CheckUsernameAvailability(String username)
        {
            int success = 0;
            try
            {
                User user = db.Users.Single(p => p.userName == username);
                success = 1;
            }
            catch (Exception e)
            {
                success = 0;
            }
            //new HRIS_WEB.Controllers.TimecardController().sendMail(recipient, null, "Password Reset.", mailbody.ToString());
            return success;
        }
        public JsonResult UpdateUser(oUser uUser)
        {
            User User = db.Users.SingleOrDefault(x => x.userId == uUser.ID);

            User.userName = uUser.username;
            User.FirstName = uUser.FirstName;
            User.SurName = uUser.SurName;
            if (uUser.Password != null)
            {
                User.emailAdd = uUser.EmailAdd;
            }
            User.Pwd = MD5Crypt.Encrypt(uUser.Password, "admin", true) ;
            User.mobileNo = uUser.Mobileno;

            try
            {
                db.SaveChanges();

                return Json(new { isError = "F", message = "Successfully Saved." });
            }
            catch (Exception ex)
            {
                return Json(new { isError = "T", message = "Could not insert data." });
            }
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
    }
}


using SampleCodeFirstIn.Context;
using SampleCodeFirstIn.Models;
using SampleCodeFirstIn.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

namespace SampleCodeFirstIn.Controllers
{
    public class POSController : BaseController
    {
        InviContext db = new InviContext();
        // GET: POS
        public ActionResult Transaction()
        {
            return View();
        }
        public JsonResult GetProductList()
        {
            StringBuilder sb = new StringBuilder();
            var prod = db.Product.Include(o => o.Category).Select(p => new { p.ProductID, p.ProdName, p.Category.CategName, p.Price, p.Stock });

            //sb.Append("<option selected='selected' value='' ></option>");

            foreach (var container in prod)
            {
                sb.Append("<option value='" + container.ProdName + "' prodID = '" + container.ProductID + "' price = '" + container.Price + "'>" + container.ProdName + "</option>");
            }
            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductDetails(int productID)
        {
            Class.Product sb = new Class.Product();
            var prod = db.Product.Include(o => o.Category).Select(p => new { p.ProductID, p.ProdName, p.Category.CategName, p.Price, p.Stock }).SingleOrDefault(p => p.ProductID == productID);

            sb.Price = prod.Price;
            sb.Stock = prod.Stock;


            return Json(sb, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ProcessOrder(Order items)
        {
            var newTransNo = GenerateNewSerial();
            db.Transactions.Add(new Transactions()
            {
                trans_No = newTransNo,
                Date = DateTime.Now,
                user = Convert.ToInt32(Session["userid"].ToString()),
                paymentType = items.items[0].paymentType,
                shiftid = 1 // Convert.ToInt32(Session["shiftid"].ToString())

            });
            foreach (Order.item i in items.items)
            {
                db.Transaction_Details.Add(new Transaction_Details()
                {
                    trans_No = newTransNo,
                    ProductID = i.ProductID,
                    price = i.price,
                    qty = i.prod_qty
                });
            }

            try
            {
                db.SaveChanges();
                return Json(new { isError = "F", message = "Successfully Saved." });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return Json(new { isError = "T", message = "Failed Saved." });
            }
        }
        private string GenerateNewSerial()
        {
            List<int> transno = new List<int>();
            foreach (var itm in db.Transactions.Select(o => o.trans_No))
                transno.Add(Convert.ToInt32(itm));

            return transno.Count > 0 ? string.Format("{0:00000000}", transno.Max() + 1) : "00000001";
        }
        public JsonResult GetProducts(string term)
        {

            var suggestions = from s in db.Product
                              select new { s.ProdName, s.ProductID, s.Price };
            var namelist = suggestions.Where(n => n.ProdName.ToLower().StartsWith(term.ToLower()));

            return Json(namelist, JsonRequestBehavior.AllowGet);
        }
    }
}
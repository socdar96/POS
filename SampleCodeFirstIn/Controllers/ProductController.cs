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


namespace SampleCodeFirstIn.Controllers
{
    public class ProductController : BaseController
    {

        InviContext db = new InviContext();
        
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetProductList()
        {
            //var qry = db.Product.Include(o => o.Category).Select(p => new { p.ProductID, p.ProdName, p.Category.CategName });
            return Json(db.Product.Include(o => o.Category).Select(p => new { p.ProductID, p.ProdName, p.Category.CategName, p.Price, p.Stock }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoryList()
        {
            StringBuilder sb = new StringBuilder();
            List<Category> categlist = db.Categories.ToList();

            foreach (var container in categlist)
            {
                    sb.Append("<option value='" + container.CategID + "' data-tokens='" + container.CategName +"' >" + container.CategName + "</option>");
            }
            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddProduct(Class.Product New_Product)
        {
            Models.Product Product = new Models.Product()
            {
                CategID = New_Product.CategID,
                ProdName = New_Product.ProdName,
                Price = New_Product.Price,
                Stock = New_Product.Stock
            };
            try
            {
                db.Product.Add(Product);
                db.SaveChanges();

                return Json(new { isError = "F", message = "Successfully Saved." });
            }
            catch(Exception ex)
            {
                return Json(new { isError = "T", message = "Could not insert data." });
            }
        }
        public JsonResult UpdateProduct(Class.Product updateProduct)
        {
            Models.Product Product = db.Product.SingleOrDefault(x => x.ProductID == updateProduct.ProductID);
            Product.CategID = updateProduct.CategID;
            Product.ProdName = updateProduct.ProdName;
            Product.Price = updateProduct.Price;
            Product.Stock = updateProduct.Stock;

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
        public JsonResult DeleteProduct(int productID = 0)
        {
            Models.Product product = db.Product.Single(x => x.ProductID == productID);

            db.Product.Remove(product);

            try
            {
                db.SaveChanges();
                return Json(new { isError = "F", message = "Successfully Deleted." });
            }
            catch (Exception ex)
            { return Json(new { isError = "T", message = "Could not delete data. " + ex.Message }); }
        }
        public JsonResult AddCategory(string CategName= null)
        {
            Category category = new Category()
            {
                CategName = CategName
            };

            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return Json(new { isError = "F", message = "Successfully Saved." });
            }
            catch (Exception ex)
            {
                return Json(new { isError = "T", message = "Could not insert data." });
            }
        }
        public JsonResult AddNewStock(int ProductID = 0, int newStock = 0)
        {
            try
            {
                Models.Product prod = db.Product.SingleOrDefault(x => x.ProductID == ProductID);
                prod.Stock = prod.Stock + newStock;
                db.SaveChanges();
                return Json(new { isError = "F", message = "Successfully Added Stock." });
            }
            catch (Exception ex)
            {
                return Json(new { isError = "T", message = "Could not Add Stock." });
            }
        }
    }
}
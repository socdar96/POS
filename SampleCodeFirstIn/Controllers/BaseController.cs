using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleCodeFirstIn.Controllers
{
    public class BaseController : Controller
    {
        //private string airlineCode = ConfigurationManager.AppSettings["AirlineCode"];
        public static string ViewName;
        public static string SessionUserID;
        //public static string SessionLoginID;
        public static string SessionUserName;
        public static bool isFromDashboardGHA = false;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
               // var entityName = ConfigurationManager.AppSettings[airlineCode + "EntityName"];
                base.OnActionExecuting(filterContext);
                if (Session["userid"] == null)
                {
                    filterContext.Result = RedirectToAction("Login", "Account", routeValues: null);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
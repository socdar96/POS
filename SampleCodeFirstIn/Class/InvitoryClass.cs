using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleCodeFirstIn.Class
{
    public class oUser
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string EmailAdd { get; set; }
        public string Password { get; set; }
        public string Mobileno { get; set; }
    }
    public class Categories
    {
        public int CategID { get; set; }
        public string CategName { get; set; }
    }
    public class Product
    {
        public int ProductID { get; set; }
        public string ProdName { get; set; }
        public int CategID { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
    public class Order
    {
        public class item
        {
            public int trans_No { get; set; }
            public int ProductID { get; set; }
            public string prod_name { get; set; }
            public int prod_qty { get; set; }
            public decimal price { get; set; }
            public decimal prod_total { get; set; }
        }

        public List<item> items { get; set; }
    }
    
}
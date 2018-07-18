namespace SampleCodeFirstIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        public string ProdName { get; set; }

        public int CategID { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Category Category { get; set; }

        [ForeignKey("ProductID")]
        public ICollection<Transaction_Details> Transaction_Details { get; set; }
    }
}

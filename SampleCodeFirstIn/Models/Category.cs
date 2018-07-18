namespace SampleCodeFirstIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [Key]
        public int CategID { get; set; }

        public string CategName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

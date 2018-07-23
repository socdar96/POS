using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleCodeFirstIn.Models
{
    public class Transaction_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transDetId { get; set; }
        public int ProductID { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }
        public string trans_No { get; set; }
        public bool isVoid { get; set; }

        public Transactions Transaction { get; set; }
    }
}
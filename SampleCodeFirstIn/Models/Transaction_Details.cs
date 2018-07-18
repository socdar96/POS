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
        public int ProductID { get; set; }
        public decimal price { get; set; }
        public decimal trans_No { get; set; }

        public Transactions Transaction { get; set; }
    }
}
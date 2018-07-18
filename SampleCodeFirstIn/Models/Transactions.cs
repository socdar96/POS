using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleCodeFirstIn.Models
{
    public class Transactions
    {
        [Key]
        public decimal trans_No { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("trans_No")]
        public ICollection<Transaction_Details> Transaction_Details { get; set; }
    }
}
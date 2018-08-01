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
        public string trans_No { get; set; }
        public DateTime Date { get; set; }
        public int user { get; set; }
        public int paymentType { get; set; }
        public int disPercent { get; set; }
        public int disAmount { get; set; }
        public int shiftid { get; set; }
        public decimal grossAmount { get; set; }
        public int cardNo { get; set; }
        public DateTime? expiryDate { get; set; }
        public string CVcode { get; set; }

        [ForeignKey("trans_No")]
        public ICollection<Transaction_Details> Transaction_Details { get; set; }
    }
}
using SampleCodeFirstIn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleCodeFirstIn.Context
{
    public class InviContext : DbContext
    {
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Product> Product { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Transaction_Details> Transaction_Details { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
    }
}
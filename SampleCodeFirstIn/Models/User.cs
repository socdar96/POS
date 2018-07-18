namespace SampleCodeFirstIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userLevel { get; set; }

        public string emailAdd { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string mobileNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool disabled { get; set; }

        public string Pwd { get; set; }

        public string userName { get; set; }
        
    }
}

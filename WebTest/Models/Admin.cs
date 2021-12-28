namespace WebTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(10)]
        public string adminId { get; set; }

        [Required]
        [StringLength(50)]
        public string adminName { get; set; }

        [Required]
        [StringLength(50)]
        public string adminEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string adminSpecialty { get; set; }

        [StringLength(10)]
        public string adminAge { get; set; }

        [StringLength(100)]
        public string adminAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string accountId { get; set; }

        public virtual Account Account { get; set; }
    }
}

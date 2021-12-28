namespace WebTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            Courses = new HashSet<Cours>();
        }

        [StringLength(10)]
        public string staffId { get; set; }

        [Required]
        [StringLength(50)]
        public string staffName { get; set; }

        [Required]
        [StringLength(50)]
        public string staffEmail { get; set; }

        [StringLength(10)]
        public string staffAge { get; set; }

        [StringLength(100)]
        public string staffAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string accountId { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cours> Courses { get; set; }
    }
}

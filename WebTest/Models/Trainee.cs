namespace WebTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainee")]
    public partial class Trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainee()
        {
            Courses = new HashSet<Cours>();
        }

        [StringLength(10)]
        public string traineeId { get; set; }

        [Required]
        [StringLength(50)]
        public string traineeName { get; set; }

        [Required]
        [StringLength(50)]
        public string traineeEmail { get; set; }

        [StringLength(10)]
        public string traineeAge { get; set; }

        public DateTime? traineeDoB { get; set; }

        [Required]
        [StringLength(50)]
        public string traineeEducation { get; set; }

        [Required]
        [StringLength(10)]
        public string accountId { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cours> Courses { get; set; }
    }
}

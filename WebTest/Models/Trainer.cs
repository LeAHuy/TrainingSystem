namespace WebTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainer")]
    public partial class Trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            Courses = new HashSet<Cours>();
        }

        [StringLength(10)]
        public string trainerId { get; set; }

        [Required]
        [StringLength(50)]
        public string trainerName { get; set; }

        [Required]
        [StringLength(50)]
        public string trainerEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string trainerSpecially { get; set; }

        [StringLength(10)]
        public string trainerAge { get; set; }

        [StringLength(100)]
        public string trainerAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string accountId { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cours> Courses { get; set; }
    }
}

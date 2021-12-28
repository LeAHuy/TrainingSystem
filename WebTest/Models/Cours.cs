namespace WebTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            Trainees = new HashSet<Trainee>();
        }

        [Key]
        [StringLength(10)]
        public string courseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string courseName { get; set; }

        [StringLength(1000)]
        public string courseDisciption { get; set; }

        [Required]
        [StringLength(10)]
        public string catId { get; set; }

        [Required]
        [StringLength(10)]
        public string traineeId { get; set; }

        [Required]
        [StringLength(10)]
        public string trainerId { get; set; }

        [Required]
        [StringLength(10)]
        public string topicId { get; set; }

        [Required]
        [StringLength(10)]
        public string staffId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual Trainer Trainer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}

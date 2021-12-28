using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebTest.Models
{
    public partial class TrainingContext : DbContext
    {
        public TrainingContext()
            : base("name=TrainingContext2")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.accountId)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.accountPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.accountRole)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Trainees)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Trainers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.adminId)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.adminName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.adminEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.adminSpecialty)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.adminAge)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.adminAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.accountId)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.catId)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.catName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.catDisciption)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.courseId)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.courseDisciption)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.catId)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.traineeId)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.trainerId)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.topicId)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.staffId)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Trainees)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("Course_Detail_Trainee").MapLeftKey("courseId").MapRightKey("traineeId"));

            modelBuilder.Entity<Staff>()
                .Property(e => e.staffId)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.staffName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.staffEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.staffAge)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.staffAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.accountId)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.topicId)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.topicName)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.topicDisciption)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.traineeId)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.traineeName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.traineeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.traineeAge)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.traineeEducation)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.accountId)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.trainerId)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.trainerName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.trainerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.trainerSpecially)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.trainerAge)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.trainerAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.accountId)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Trainer)
                .WillCascadeOnDelete(false);
        }
    }
}

namespace EFDemoCodeFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CPContext : DbContext
    {
        public CPContext()
            : base("name=CPContext")
        {
        }

        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);
        }
    }
}

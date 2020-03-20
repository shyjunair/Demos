namespace EFDemoCodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int Id { get; set; }

        public short SchoolId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public virtual School School { get; set; }
    }
}

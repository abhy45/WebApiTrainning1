using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FifthExample_RepoPattern.Models
{
    [Table("Student")]
    public partial class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }
        [Required]
        [StringLength(20)]
        public string Phoneno { get; set; }
        [Required]
        [StringLength(10)]
        public string CurrentClass { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondExample_CFWebApi.Models
{
    public class Student
    {
        [Column(Order =0)]
        public int StudentId { get; set; }
        
        [Column("Name", Order =1)]
        [StringLength(200)]
        public string StudentName { get; set; }

        [Column("DoB", Order = 2, TypeName = "dateTime")]
        public DateTime DateOfBirth { get; set; }
    }
}

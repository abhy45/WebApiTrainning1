using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FifthExample_RepoPattern.Services
{

    public class StudentEntity
    {

        [Range(10,40,ErrorMessage ="StudentID is wrong")]
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string Phoneno { get; set; }

        public string CurrentClass { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FourthExample_Customization.Models
{
    //public class Student
    //{
    //    [Required(ErrorMessage ="Student iD is a must")]
    //    [Range(100,200, ErrorMessage = "EmpID should be b/w 100 to 200")]
    //    public int StudentId { get; set; }

    //    [Required(ErrorMessage ="Name is mandatory")]
    //    public string StudentName { get; set; }

    //    [Required(ErrorMessage ="Phone no is must")]
    //    [StringLength(10, ErrorMessage ="Invalid Phone no")]
    //    public string PhoneNo { get; set; }
    //}
    //////////////////////Implement IValidateObject interface////////////
    public class Student : IValidatableObject
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string PhoneNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StudentId < 100 || StudentId > 200)
                yield return new ValidationResult("Student ID should be b/w 101 to 199");
            if(string.IsNullOrEmpty(StudentName))
                yield return new ValidationResult("Student Name is mandatory");
        }
    }

}

using FourthExample_Customization.Data;
using FourthExample_Customization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourthExample_Customization.Customization;
namespace FourthExample_Customization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentsController : ControllerBase
    {
        [HttpGet("AllStudents")]
        
        public ActionResult Get()
        {
            return Ok(DataManager.GetStudents());
        }

        [HttpPost("AddStudent")]
        [MyCustomValidatorFilter]
        public ActionResult Post(Student s)
        {
            DataManager.AddStudent(s);
            return Ok();
        }
    }
}

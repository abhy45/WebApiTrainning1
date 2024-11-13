using FifthExample_RepoPattern.Models;
using FifthExample_RepoPattern.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifthExample_RepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _student;
        public StudentsController(IStudentRepository student)
        {
            this._student = student;
        }
        // GET: api/<StudentsController>
        [HttpGet("AllStudent")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            //return Ok(await _context.Students.ToListAsync());
            return Ok(await _student.Get());
        }

        //[HttpGet("{id}",Name ="FindStudent")]
        [HttpGet("FindStudent/{id}")]
        public async Task<ActionResult<Student>> FindStudent(int id)
        {
            return await _student.Get(id);
        }
        [HttpPost("AddStudent")]
        public async Task AddStudent(StudentEntity student)
        {
            Student row = new Student
            {
                CurrentClass = student.CurrentClass,
                Phoneno = student.Phoneno,
                StudentName = student.StudentName,
                StudentId = student.StudentId
            };
            await _student.Add(row);
        }

        [HttpPut("UpdateAllStudent")]
        public async Task UpdateStudent(Student student)
        {
            //Using Task.Run(() => ) for void functions.
            await _student.Update(student);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async void DeleteStudent(int id)
        {
            _student.Delete(id);
        }
    }
}

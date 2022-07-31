using backend_ScholarshipPortal.Models;
using backend_ScholarshipPortal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_ScholarshipPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();
        [HttpGet]
        [Route("StudentDetails")]
        public IActionResult GetStudentDetails()
        {
            var data = from d in db.Students select d;
            return Ok(data);
        }
        [HttpGet]
        [Route("StudentDetails/{id}")]
        public IActionResult GetStudentDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("id cannot be null");
            }
            var data = (from d in db.Students where d.StudentId == id select d).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"Student {id} not present");
            }
            return Ok(data);
        }
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult PostStudent(Student student)
        {
            Student data1 = new Student();
            if (ModelState.IsValid)
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    data1 = (from d in db.Students where d.Aadhaar == student.Aadhaar select d).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Record successfully added",data1.StudentId);
        }
        [HttpPost]
        [Route("StudentLogin")]
        public IActionResult PostStudentLogin(StudentLogin login)
        {
            var data = db.Students.ToList();
            var student = (from d in data where d.Aadhaar == login.Aadhaar && d.Password == login.Password select d).FirstOrDefault();

            if (student == null)
                return BadRequest("Username or Password is Incorrect");
            return Ok(student.StudentId);
        }
    }
}

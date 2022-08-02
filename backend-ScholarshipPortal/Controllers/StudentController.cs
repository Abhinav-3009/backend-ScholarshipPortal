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


        //Method to fetch all student details
        [HttpGet]
        [Route("StudentDetails")]
        public IActionResult GetStudentDetails()
        {
            var data = from d in db.Students select d;
            return Ok(data);
        }


        //to fetch details of a specific student with it's ID
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


        /// <summary>
        /// method to add a new student in the database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
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
                    //to fetch student id and pass it to the frontend
                    data1 = (from d in db.Students where d.Aadhaar == student.Aadhaar select d).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Record successfully added",data1);
        }


        /// <summary>
        /// method to check login details
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
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


        /// <summary>
        /// method to check approval status
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ApprovalStatus/{id}")]
        public IActionResult GetApprovalStatus(int studentId)
        {
            ScholarshipApproval data = new ScholarshipApproval();

            var appId = db.ScholarshipApplications.Where(d => d.StudentId == studentId).FirstOrDefault();
            data = db.ScholarshipApprovals.Where(d => d.ApplicationId == appId.ApplicationId).FirstOrDefault();



            return Ok(data);
        }
    }
}

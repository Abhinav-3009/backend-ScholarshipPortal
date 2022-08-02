using backend_ScholarshipPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_ScholarshipPortal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ScholarshipApplicationController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();

        //[HttpGet]
        //[Route("ApplicationForOfficer")]
        //public IActionResult GetScholarshipApplicationForOfficer()
        //{
        //    var data = db.ScholarshipApplications.Include("ScholarshipApproval").ToList();
        //    Console.WriteLine(data);
        //    return Ok(data);
        //}
        [HttpPost]
        [Route("AddScholarshipApplication")]
        public IActionResult PostScholarshipApplication(ScholarshipApplication scholarshipApplication)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentdata = db.Students.Find(scholarshipApplication.StudentId);
                    var institutedata = db.Institutes.Where(d => d.Institutecode == studentdata.Institutecode).FirstOrDefault();
                    scholarshipApplication.InstituteId = institutedata.InstituteId;
                    db.ScholarshipApplications.Add(scholarshipApplication);
                    db.SaveChanges();
                    ScholarshipApproval approval = new ScholarshipApproval();
                    var data = db.ScholarshipApplications.ToList();
                    var appid = (from d in data where d.StudentId == scholarshipApplication.StudentId select d.ApplicationId).FirstOrDefault();
                    approval.ApplicationId = appid;
                    db.ScholarshipApprovals.Add(approval);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Application successfully added", scholarshipApplication);
        }
        [HttpGet]
        [Route("FindScholarshipApplication/{id}")]
        public IActionResult GetScholarshipApplication(int? id)
        {
            if (id == null)
            {
                return BadRequest("id cannot be null");
            }
            var data = (from d in db.ScholarshipApplications where d.ApplicationId == id select d).FirstOrDefault();
            //var data = (from d in db.ScholarshipApplications where d.ApplicationId == id select new { d.Religion, d.Community, d.State }).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"Application {id} not present");
            }
            return Ok(data);
        }

    }


}

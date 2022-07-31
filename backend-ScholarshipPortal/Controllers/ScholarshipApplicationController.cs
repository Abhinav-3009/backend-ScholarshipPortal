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

        [HttpGet]
        [Route("ApplicationForOfficer")]
        public IActionResult GetScholarshipApplicationForOfficer()
        {
            var data = db.ScholarshipApplications.Include("ScholarshipApproval").ToList();
            Console.WriteLine(data);
            return Ok(data);
        }
        [HttpPost]
        [Route("AddScholarshipApplication")]
        public IActionResult PostScholarshipApplication(ScholarshipApplication scholarshipApplication)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
                    return BadRequest(ex.Message);
                }
            }
            return Created("Application successfully added", scholarshipApplication);
        }

    }


}

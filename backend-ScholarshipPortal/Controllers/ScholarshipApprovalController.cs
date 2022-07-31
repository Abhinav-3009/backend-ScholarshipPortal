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
    public class ScholarshipApprovalController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();
        [HttpGet]
        [Route("ScholarshipForInstitute/{id}")]
        public IActionResult GetScholarshipForInstitute(int? id)
        {
            //Console.WriteLine("Hello World");
            var data = db.ScholarshipApprovals.Include("Application").Where(d => d.ApprovedByInstitute == 0 && d.Application.InstituteId==id).ToList();
            var appl = (from d in data select new { d.Application.Religion, d.Application.Community, d.Application.Fathername });

            Console.WriteLine(data);

            return Ok(appl);
        }
        [HttpGet]
        [Route("ScholarshipForOfficer")]
        public IActionResult GetScholarshipForOfficer()
        {
            //Console.WriteLine("Hello World");
            var data = db.ScholarshipApprovals.Include("Application").Where(d => d.ApprovedByInstitute == 1 && d.ApprovedByNodalOfficer==0).ToList();

            Console.WriteLine(data);

            return Ok(data);
        }
        [HttpGet]
        [Route("ScholarshipForMinistry")]
        public IActionResult GetScholarshipForMinistry()
        {
            Console.WriteLine("Hello World");
            var data = db.ScholarshipApprovals.Include("Application").Where(d => d.ApprovedByNodalOfficer == 1 && d.ApprovedByMinistry == 0).ToList();

            Console.WriteLine(data);

            return Ok(data);
        }
        [HttpPut]
        [Route("ApproveRequestByInstitute")]
        public IActionResult PutApproveRequestByInstitute([FromForm] int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Find(id);
            data.ApprovedByInstitute= 1;
            db.SaveChanges();
            return Ok(data);
        }
        [HttpPut]
        [Route("ApproveRequestByOfficer")]
        public IActionResult PutApproveRequestByOfficer([FromForm] int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Find(id);
            data.ApprovedByNodalOfficer = 1;
            db.SaveChanges();
            return Ok(data);
        }
        [HttpPut]
        [Route("ApproveRequestByMinistry")]
        public IActionResult PutApproveRequestByMinistry([FromForm] int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Find(id);
            data.ApprovedByMinistry = 1;
            db.SaveChanges();
            return Ok(data);
        }
    }
}

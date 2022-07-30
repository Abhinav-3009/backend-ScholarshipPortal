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
    public class InstituteApprovalController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();

        [HttpGet]
        [Route("InstituteForOfficer")]
        public IActionResult GetInstituteForOfficer()
        {
            //Console.WriteLine("Hello World");
            var data = db.InstituteApprovals.Include("Institute").Where(d=>d.ApprovedByNodalOfficer==0).ToList();
            
            Console.WriteLine(data);
            
            return Ok(data);
        }
        [HttpGet]
        [Route("InstituteForMinistry")]
        public IActionResult GetInstituteForMinistry()
        {
            Console.WriteLine("Hello World");
            var data = db.InstituteApprovals.Include("Institute").Where(d => d.ApprovedByNodalOfficer == 1 && d.ApprovedByMinistry==0).ToList();

            Console.WriteLine(data);

            return Ok(data);
        }

        [HttpPut]
        [Route("ApproveRequestByOfficer")]
        public IActionResult PutApproveRequestByOfficer([FromForm] int id)
        {
            InstituteApproval data = db.InstituteApprovals.Find(id);
            data.ApprovedByNodalOfficer = 1;
            db.SaveChanges();
            return Ok(data);
        }
        [HttpPut]
        [Route("ApproveRequestByMinistry")]
        public IActionResult PutApproveRequestByMinistry([FromForm] int id)
        {
            InstituteApproval data = db.InstituteApprovals.Find(id);
            data.ApprovedByMinistry = 1;
            db.SaveChanges();
            return Ok(data);
        }
    }
}
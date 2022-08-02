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


        /// <summary>
        /// method to get applications according to a specific institute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ScholarshipForInstitute/{id}")]
        public IActionResult GetScholarshipForInstitute(int? id)
        {
            //Console.WriteLine("Hello World");
            var data = db.ScholarshipApprovals.Include("Application").Where(d => d.ApprovedByInstitute == 0 && d.Application.InstituteId == id).ToList();
            var appl = (from d in data select new { d.ApplicationId, d.Application.StudentId, d.Application.ScholarshipId, d.Application.PresentCourse });

            Console.WriteLine(data);

            return Ok(appl);
        }


        /// <summary>
        /// method to get applications for the officer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ScholarshipForOfficer")]
        public IActionResult GetScholarshipForOfficer()
        {
            //Console.WriteLine("Hello World");
            //var data = db.ScholarshipApprovals.Include("Application").Where(d => d.ApprovedByInstitute == 1 && d.ApprovedByNodalOfficer==0).ToList();

            var data = from d in db.ScholarshipApprovals.Include("Application")
                       where d.ApprovedByInstitute == 1 && d.ApprovedByNodalOfficer == 0
                       select new
                       {
                           d.ApplicationId,
                           d.Application.StudentId,
                           d.Application.ScholarshipId,
                           d.Application.PresentCourse
                       };

            Console.WriteLine(data);

            return Ok(data);
        }


        /// <summary>
        /// method to get applications for the ministry
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ScholarshipForMinistry")]
        public IActionResult GetScholarshipForMinistry()
        {
            var data = from d in db.ScholarshipApprovals.Include("Application")
                       where  d.ApprovedByNodalOfficer == 1 && d.ApprovedByMinistry == 0
                       select new
                       {
                           d.ApplicationId,
                           d.Application.StudentId,
                           d.Application.ScholarshipId,
                           d.Application.PresentCourse
                       };
            
            Console.WriteLine(data);

            return Ok(data);
        }


        /// <summary>
        /// method to approve applications by the institute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ApproveByInstitute/{id}")]
        public IActionResult PutApproveRequestByInstitute(int id)
        {

            ScholarshipApproval data = db.ScholarshipApprovals.Where(d => d.ApplicationId == id).FirstOrDefault();
            data.ApprovedByInstitute= 1;
            db.SaveChanges();
            return Ok(data);
        }


        /// <summary>
        /// method to reject applications by the institute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("RejectByInstitute/{id}")]
        public IActionResult PutRejectRequestByInstitute(int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Where(d => d.ApplicationId == id).FirstOrDefault();
            data.ApprovedByInstitute = 2;
            db.SaveChanges();
            return Ok(data);
        }



        /// <summary>
        /// method to approve applications by the officer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ApproveByOfficer/{id}")]
        public IActionResult PutApproveRequestByOfficer(int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Where(d=> d.ApplicationId==id).FirstOrDefault();
            data.ApprovedByNodalOfficer = 1;
            db.SaveChanges();
            return Ok(data);
        }



        /// <summary>
        /// method to reject applications by the institute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("RejectByOfficer")]
        public IActionResult PutRejectRequestByOfficer(int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Where(d => d.ApplicationId == id).FirstOrDefault();
            data.ApprovedByNodalOfficer = 2;
            db.SaveChanges();
            return Ok(data);
        }


        /// <summary>
        /// method to approve applications by the miinistry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ApproveByMinistry/{id}")]
        public IActionResult PutApproveRequestByMinistry( int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Where(d => d.ApplicationId == id).FirstOrDefault();
            data.ApprovedByMinistry = 1;
            db.SaveChanges();
            return Ok(data);
        }



        /// <summary>
        /// method to reject applications by the ministry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("RejectByMinistry")]
        public IActionResult PutRejectRequestByMinistry(int id)
        {
            ScholarshipApproval data = db.ScholarshipApprovals.Where(d => d.ApplicationId == id).FirstOrDefault();
            data.ApprovedByMinistry = 2;
            db.SaveChanges();
            return Ok(data);
        }
    }
}

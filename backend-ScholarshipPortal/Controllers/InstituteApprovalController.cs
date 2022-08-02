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



        /// <summary>
        /// method to fetch institute registration details for officer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("InstituteForOfficer/")]
        public IActionResult GetInstituteForOfficer()
        {
            //var data = from d in db.ScholarshipApprovals.Include("Application")
            //           where d.ApprovedByInstitute == 1 && d.ApprovedByNodalOfficer == 0
            //           select new
            //           {
            //               d.ApplicationId,
            //               d.Application.StudentId,
            //               d.Application.ScholarshipId,
            //               d.Application.PresentCourse
            //           };

            //Console.WriteLine(data);

            //return Ok(data);


            //Console.WriteLine("Hello World");
            var data = from d in db.InstituteApprovals.Include("Institute")
                       where d.ApprovedByNodalOfficer == 0
                       select new
                       {
                           d.InstituteId,
                           d.Institute.InstituteCategory,
                           d.Institute.Name
                       };
            
            Console.WriteLine(data);
            
            return Ok(data);
        }


        /// <summary>
        /// method to fetch institute registration details for ministry
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("InstituteForMinistry")]
        public IActionResult GetInstituteForMinistry()
        {
            var data = from d in db.InstituteApprovals.Include("Institute")
                       where d.ApprovedByMinistry == 0
                       select new
                       {
                           d.InstituteId,
                           d.Institute.InstituteCategory,
                           d.Institute.Name
                       };

            Console.WriteLine(data);

            return Ok(data);
        }



        /// <summary>
        /// method to approve institute registration details by officer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ApproveRequestByOfficer/{id}")]
        public IActionResult PutApproveRequestByOfficer(int id)
        {
            InstituteApproval data = db.InstituteApprovals.Where(d=> d.InstituteId==id).FirstOrDefault();
            data.ApprovedByNodalOfficer = 1;
            db.SaveChanges();
            return Ok(data);
        }



        /// <summary>
        /// method to reject institute registration details by officer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("RejectRequestByOfficer/{id}")]
        public IActionResult PutRejectRequestByOfficer(int id)
        {
            InstituteApproval data = db.InstituteApprovals.Where(d => d.InstituteId == id).FirstOrDefault();
            data.ApprovedByNodalOfficer = 2;
            db.SaveChanges();
            return Ok(data);
        }



        /// <summary>
        /// method to approve institute registration details by ministry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ApproveRequestByMinistry/{id}")]
        public IActionResult PutApproveRequestByMinistry(int id)
        {
            InstituteApproval data = db.InstituteApprovals.Where(d => d.InstituteId == id).FirstOrDefault();
            data.ApprovedByMinistry = 1;
            db.SaveChanges();
            return Ok(data);
        }



        /// <summary>
        /// method to reject institute registration details by ministry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("RejectRequestByMinistry/{id}")]
        public IActionResult PutRejectRequestByMinistry(int id)
        {
            InstituteApproval data = db.InstituteApprovals.Where(d => d.InstituteId == id).FirstOrDefault();
            data.ApprovedByNodalOfficer = 2;
            db.SaveChanges();
            return Ok(data);
        }
    }
}
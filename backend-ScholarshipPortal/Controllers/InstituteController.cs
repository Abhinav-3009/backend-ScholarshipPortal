using backend_ScholarshipPortal.Models;
using backend_ScholarshipPortal.ViewModel;
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
    public class InstituteController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();


        /// <summary>
        /// method to fetch institute details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("InstituteDetails")]
        public IActionResult GetInstituteDetails()
        {
            var data = from d in db.Institutes select d;
            return Ok(data);
        }


        /// <summary>
        /// method to fetch specific institute details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("InstituteDetails/{id}")]
        public IActionResult GetInstituteDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("id cannot be null");
            }
            var data = (from d in db.Institutes where d.InstituteId == id select d).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"Institute {id} not present");
            }
            return Ok(data);
        }



        /// <summary>
        /// method to add institute details int the database
        /// </summary>
        /// <param name="institute"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddInstitute")]
        public IActionResult PostInstituteDetails(Institute institute)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Institutes.Add(institute);
                    db.SaveChanges();
                    InstituteApproval approval = new InstituteApproval();
                    var data = db.Institutes.ToList();
                    var insid = (from d in data where d.Institutecode == institute.Institutecode select d.InstituteId).FirstOrDefault();
                    approval.InstituteId = insid;
                    db.InstituteApprovals.Add(approval);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException.Message);
                }
            }
            return Created("Registration successfull", institute);
        }
        //[HttpGet]
        //[Route("InstituteForOfficer")]
        //public IActionResult GetInstituteForOfficer()
        //{
        //    //var data = db.Institutes.Include("InstituteApproval").Where(d => d.InstituteApproval.ApprovedByNodalOfficer == 0);
        //    //Console.WriteLine(data);
        //    var data =db.Database.ExecuteSqlInterpolated($"getofficerapprovalforinstitute");
        //    //db.Database.ExecuteSqlInterpolated($"adddept {dept.Id} ,{dept.Name}, {dept.Location}");
        //    return Ok(data);
        //}


        /// <summary>
        /// method to fetch login details of institute
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InstituteLogin")]
        public IActionResult PostStudentLogin(InstituteLogin login)
        {
            var data = db.Institutes.ToList();
            var institute = (from d in data where d.Institutecode == login.InstituteCode && d.Password == login.Password select d).FirstOrDefault();

            if (institute == null)
                return BadRequest("Username or Password is Incorrect");
            return Ok(institute.InstituteId);
        }



        /// <summary>
        /// method to find institute application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindInstituteApplication/{id}")]
        public IActionResult GetInstituteApplication(int? id)
        {
            if (id == null)
            {
                return BadRequest("id cannot be null");
            }
            var data = (from d in db.Institutes where d.InstituteId == id select d).FirstOrDefault();
            //var data = (from d in db.ScholarshipApplications where d.ApplicationId == id select new { d.Religion, d.Community, d.State }).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"Application {id} not present");
            }
            return Ok(data);
        }

    }
}

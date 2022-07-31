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
        [HttpGet]
        [Route("InstituteDetails")]
        public IActionResult GetInstituteDetails()
        {
            var data = from d in db.Institutes select d;
            return Ok(data);
        }


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
        [HttpGet]
        [Route("InstituteForOfficer")]
        public IActionResult GetInstituteForOfficer()
        {
            //var data = db.Institutes.Include("InstituteApproval").Where(d => d.InstituteApproval.ApprovedByNodalOfficer == 0);
            //Console.WriteLine(data);
            var data =db.Database.ExecuteSqlInterpolated($"getofficerapprovalforinstitute");
            //db.Database.ExecuteSqlInterpolated($"adddept {dept.Id} ,{dept.Name}, {dept.Location}");
            return Ok(data);
        }
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

    }
}

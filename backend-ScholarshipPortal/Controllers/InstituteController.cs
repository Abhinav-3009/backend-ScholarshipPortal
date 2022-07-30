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
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
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

    }
}

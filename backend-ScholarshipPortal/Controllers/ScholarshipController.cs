using backend_ScholarshipPortal.Models;
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
    public class ScholarshipController : ControllerBase
    {
        ScholarshipPortalContext db = new ScholarshipPortalContext();
        [HttpGet]
        [Route("ScholarshipDetails")]
        public IActionResult GetScholarshipDetails()
        {
            var data = from d in db.Scholarships select d;
            return Ok(data);
        }
        [HttpGet]
        [Route("ScholarshipDetails/{id}")]
        public IActionResult GetScholarshipDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest("id cannot be null");
            }
            var data = (from d in db.Scholarships where d.ScholarshipId == id select d).FirstOrDefault();
            if (data == null)
            {
                return NotFound($"Scholarship {id} not present");
            }
            return Ok(data);
        }

    }
}

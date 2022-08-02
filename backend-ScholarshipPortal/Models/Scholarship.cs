using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
    /// <summary>
    /// This cs file represents the structure of Scholarship table in the database.
    /// This will be used to create objects for processing of Scholarship data and retrive and send data to frontend.
    /// </summary>
    public partial class Scholarship
    {
        public Scholarship()
        {
            ScholarshipApplications = new HashSet<ScholarshipApplication>();
        }

        public int ScholarshipId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ScholarshipApplication> ScholarshipApplications { get; set; }
    }
}

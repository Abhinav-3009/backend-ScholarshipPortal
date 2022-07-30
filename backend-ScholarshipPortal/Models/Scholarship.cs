using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
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

using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
    public partial class ScholarshipApproval
    {
        public int ApprovalId { get; set; }
        public int ApplicationId { get; set; }
        public short ApprovedByInstitute { get; set; }
        public short ApprovedByNodalOfficer { get; set; }
        public short ApprovedByMinistry { get; set; }

        public virtual ScholarshipApplication Application { get; set; }
    }
}

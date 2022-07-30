using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
    public partial class InstituteApproval
    {
        public int InstituteApprovalId { get; set; }
        public int InstituteId { get; set; }
        public short ApprovedByNodalOfficer { get; set; }
        public short ApprovedByMinistry { get; set; }

        public virtual Institute Institute { get; set; }
    }
}

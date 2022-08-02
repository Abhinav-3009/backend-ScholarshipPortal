using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
    /// <summary>
    /// This cs file represents the structure of Institute Approval table in the backend.
    /// This will be used to create objects for processing of Institute Approval data and retrive and send data to frontend.
    ///</summary>
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

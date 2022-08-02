using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
    /// <summary>
    /// This cs file represents the structure of Scholarship Application table in the backend.
    /// This will be used to create objects for processing of Application  data and retrive and send data to frontend.
    /// </summary>
    public partial class ScholarshipApplication
    {
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        public int InstituteId { get; set; }
        public string Religion { get; set; }
        public string Community { get; set; }
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public double AnnualIncome { get; set; }
        public string InstituteName { get; set; }
        public string PresentCourse { get; set; }
        public string PresentCourseYear { get; set; }
        public string ModeOfStudy { get; set; }
        public DateTime ClassStartDate { get; set; }
        public string UniversityBoardName { get; set; }
        public string PreviousCourse { get; set; }
        public string PreviousPassingYear { get; set; }
        public double PreviousCoursePercentage { get; set; }
        public int RollNumber10th { get; set; }
        public string BoardName10th { get; set; }
        public string PassingYear10th { get; set; }
        public double Percentage10th { get; set; }
        public int RollNumber12th { get; set; }
        public string BoardName12th { get; set; }
        public string PassingYear12th { get; set; }
        public double Percentage12th { get; set; }
        public double AdmissionFee { get; set; }
        public double TuitionFee { get; set; }
        public double OtherFee { get; set; }
        public string IsDisabled { get; set; }
        public string DisabilityType { get; set; }
        public double DisabilityPercentage { get; set; }
        public string MaritalStatus { get; set; }
        public string ParentsProfession { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public int ScholarshipId { get; set; }

        public virtual Institute Institute { get; set; }
        public virtual Scholarship Scholarship { get; set; }
        public virtual Student Student { get; set; }
        public virtual ScholarshipApproval ScholarshipApproval { get; set; }
    }
}

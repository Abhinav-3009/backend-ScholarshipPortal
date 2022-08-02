using System;
using System.Collections.Generic;

#nullable disable

namespace backend_ScholarshipPortal.Models
{
    public partial class Student
    {
        /// <summary>
        /// This cs file represents the structure of student table in the backend.
        /// This will be used to create objects for processing of student data and retrive and send data to frontend.
        /// </summary>
        public Student()
        {
            ScholarshipApplications = new HashSet<ScholarshipApplication>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int Institutecode { get; set; }
        public string Aadhaar { get; set; }
        public string Bankname { get; set; }
        public string Accountno { get; set; }
        public string BankIfsc { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ScholarshipApplication> ScholarshipApplications { get; set; }
    }
}

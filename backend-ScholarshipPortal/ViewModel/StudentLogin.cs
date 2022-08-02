using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_ScholarshipPortal.ViewModel
{
    /// <summary>
    /// model to structure login data for Student
    /// </summary>
    public class StudentLogin
    {
        public string Aadhaar { get; set; }
        public string Password { get; set; }
    }
}

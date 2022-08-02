using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_ScholarshipPortal.ViewModel
{
    /// <summary>
    /// model to structure login data for institute
    /// </summary>
    public class InstituteLogin
    {
        public int InstituteCode { get; set; }
        public string Password { get; set; }
    }
}

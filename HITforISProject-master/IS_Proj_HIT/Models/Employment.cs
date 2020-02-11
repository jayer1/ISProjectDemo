using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Employment
    {
        public Employment()
        {
            Patient = new HashSet<Patient>();
        }

        public int EmploymentId { get; set; }
        public string EmployerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Occupation { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}

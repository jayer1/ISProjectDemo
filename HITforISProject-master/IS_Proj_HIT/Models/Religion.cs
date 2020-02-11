using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Religion
    {
        public Religion()
        {
            Patient = new HashSet<Patient>();
        }

        public short ReligionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}

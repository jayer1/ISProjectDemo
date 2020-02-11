using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PreferredContactTime
    {
        public PreferredContactTime()
        {
            PatientContactDetails = new HashSet<PatientContactDetails>();
        }

        public int ContactTimeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PatientContactDetails> PatientContactDetails { get; set; }
    }
}

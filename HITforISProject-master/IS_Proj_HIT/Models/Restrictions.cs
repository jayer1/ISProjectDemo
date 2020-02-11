using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Restrictions
    {
        public Restrictions()
        {
            PatientRestrictions = new HashSet<PatientRestrictions>();
        }

        public short RestrictionId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PatientRestrictions> PatientRestrictions { get; set; }
    }
}

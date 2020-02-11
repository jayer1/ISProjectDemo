using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PatientRestrictions
    {
        public long RestrictionId { get; set; }
        public DateTime LastModified { get; set; }
        public short RestrictionTypeId { get; set; }
        public long PatientAlertId { get; set; }

        public virtual PatientAlerts PatientAlert { get; set; }
        public virtual Restrictions RestrictionType { get; set; }
    }
}

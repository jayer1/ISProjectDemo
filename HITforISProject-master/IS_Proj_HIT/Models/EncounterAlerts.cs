using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class EncounterAlerts
    {
        public long EncounterId { get; set; }
        public long PatientAlertId { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Encounter Encounter { get; set; }
        public virtual PatientAlerts PatientAlert { get; set; }
    }
}

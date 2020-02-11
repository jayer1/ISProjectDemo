using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PatientClinicalReminders
    {
        public long PatientClinicalReminderId { get; set; }
        public long PatientAlertId { get; set; }
        public short ClinicalReminderId { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ClinicalReminders ClinicalReminder { get; set; }
        public virtual PatientAlerts PatientAlert { get; set; }
    }
}

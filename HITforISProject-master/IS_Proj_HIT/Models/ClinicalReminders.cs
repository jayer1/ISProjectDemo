using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class ClinicalReminders
    {
        public ClinicalReminders()
        {
            PatientClinicalReminders = new HashSet<PatientClinicalReminders>();
        }

        public short ClinicalReminderId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PatientClinicalReminders> PatientClinicalReminders { get; set; }
    }
}

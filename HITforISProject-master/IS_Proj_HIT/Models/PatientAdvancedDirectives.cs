using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PatientAdvancedDirectives
    {
        public long PatientAdvancedDirectiveId { get; set; }
        public long PatientAlertId { get; set; }
        public short AdvancedDirectiveId { get; set; }
        public DateTime LastModified { get; set; }

        public virtual AdvancedDirectives AdvancedDirective { get; set; }
        public virtual PatientAlerts PatientAlert { get; set; }
    }
}

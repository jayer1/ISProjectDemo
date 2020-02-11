using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS_Proj_HIT.Models
{
    public partial class PatientFallRisks
    {
        public long PatientFallRiskId { get; set; }
        public DateTime LastModified { get; set; }
        public long PatientAlertId { get; set; }
        public byte FallRiskId { get; set; }

        public virtual FallRisks FallRisk { get; set; }
        public virtual PatientAlerts PatientAlert { get; set; }
    }
}

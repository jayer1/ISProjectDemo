using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class FallRisks
    {
        public FallRisks()
        {
            PatientFallRisks = new HashSet<PatientFallRisks>();
        }

        public byte FallRiskId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PatientFallRisks> PatientFallRisks { get; set; }
    }
}

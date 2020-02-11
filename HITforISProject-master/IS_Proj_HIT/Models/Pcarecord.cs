using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Pcarecord
    {
        public Pcarecord()
        {
            CareSystemAssessment = new HashSet<CareSystemAssessment>();
            Pcacomment = new HashSet<Pcacomment>();
        }

        public int Pcaid { get; set; }
        public long EncounterId { get; set; }
        public int? TempRouteTypeId { get; set; }
        public int? PulseRouteTypeId { get; set; }
        public int? O2deliveryTypeId { get; set; }
        public int? PainScaleTypeId { get; set; }
        public decimal? Temperature { get; set; }
        public byte? Pulse { get; set; }
        public byte? Respiration { get; set; }
        public byte? SystolicBloodPressure { get; set; }
        public byte? DiastolicBloodPressure { get; set; }
        public byte? PulseOximetry { get; set; }
        public string OxygenFlow { get; set; }
        public byte? PainLevelGoal { get; set; }
        public byte? PainLevelActual { get; set; }
        public DateTime? DateVitalsAdded { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Encounter Encounter { get; set; }
        public virtual O2deliveryType O2deliveryType { get; set; }
        public virtual PainScaleType PainScaleType { get; set; }
        public virtual PulseRouteType PulseRouteType { get; set; }
        public virtual TempRouteType TempRouteType { get; set; }
        public virtual ICollection<CareSystemAssessment> CareSystemAssessment { get; set; }
        public virtual ICollection<Pcacomment> Pcacomment { get; set; }
    }
}

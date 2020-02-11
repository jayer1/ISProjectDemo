using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Encounter
    {
        public Encounter()
        {
            EncounterAlerts = new HashSet<EncounterAlerts>();
            Pcarecord = new HashSet<Pcarecord>();
        }

        public string Mrn { get; set; }
        public long? EncounterRestrictionId { get; set; }
        public long EncounterId { get; set; }
        public int FacilityId { get; set; }
        public byte PatientCurrentAge { get; set; }
        public DateTime AdmitDateTime { get; set; }
        public string ChiefComplaint { get; set; }
        public int? EncounterTypeId { get; set; }
        public int PlaceOfServiceId { get; set; }
        public int AdmitTypeId { get; set; }
        public string RoomNumber { get; set; }
        public long EncounterPhysiciansId { get; set; }
        public bool FacilityRegistryOptInOut { get; set; }
        public int? DepartmentId { get; set; }
        public int PointOfOriginId { get; set; }
        public long? PaymentId { get; set; }
        public DateTime? DischargeDateTime { get; set; }
        public int? DischargeDisposition { get; set; }
        public DateTime LastModified { get; set; }

        public virtual AdmitType AdmitType { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Discharge DischargeDispositionNavigation { get; set; }
        public virtual EncounterPhysicians EncounterPhysicians { get; set; }
        public virtual EncounterType EncounterType { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Patient MrnNavigation { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual PlaceOfServiceOutPatient PlaceOfService { get; set; }
        public virtual PointOfOrigin PointOfOrigin { get; set; }
        public virtual ICollection<EncounterAlerts> EncounterAlerts { get; set; }
        public virtual ICollection<Pcarecord> Pcarecord { get; set; }
    }
}

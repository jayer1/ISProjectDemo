using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_Proj_HIT.ViewModels
{
    public class EncounterPatientViewModel
    {

        public EncounterPatientViewModel()
        { }
        public EncounterPatientViewModel(string Mrn, long EncounterId, DateTime AdmitDateTime,
            string FirstName, string LastName, string FacilityName, string DischargeDateTime)
        {
            this.Mrn = Mrn;
            this.EncounterId = EncounterId;
            this.AdmitDateTime = AdmitDateTime;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FacilityName = FacilityName;
            this.DischargeDateTime = DischargeDateTime;
        }
        public string Mrn { get; set; }
        public long EncounterId { get; set; }
        public DateTime AdmitDateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacilityName { get; set; }
        public string DischargeDateTime { get; set; }
    }
}

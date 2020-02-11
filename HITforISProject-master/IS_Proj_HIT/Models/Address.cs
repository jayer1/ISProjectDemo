using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Address
    {
        public Address()
        {
            Facility = new HashSet<Facility>();
            Insurance = new HashSet<Insurance>();
            PatientContactDetailsMailingAddress = new HashSet<PatientContactDetails>();
            PatientContactDetailsResidenceAddress = new HashSet<PatientContactDetails>();
            PatientEmergencyContact = new HashSet<PatientEmergencyContact>();
            Physician = new HashSet<Physician>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Facility> Facility { get; set; }
        public virtual ICollection<Insurance> Insurance { get; set; }
        public virtual ICollection<PatientContactDetails> PatientContactDetailsMailingAddress { get; set; }
        public virtual ICollection<PatientContactDetails> PatientContactDetailsResidenceAddress { get; set; }
        public virtual ICollection<PatientEmergencyContact> PatientEmergencyContact { get; set; }
        public virtual ICollection<Physician> Physician { get; set; }
    }
}

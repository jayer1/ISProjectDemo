using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Physician
    {
        public Physician()
        {
            EncounterPhysicians = new HashSet<EncounterPhysicians>();
        }

        public int PhysicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Credentials { get; set; }
        public string License { get; set; }
        public int? AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? SpecialtyId { get; set; }
        public int? ProviderTypeId { get; set; }
        public byte? ProviderStatus { get; set; }
        public DateTime LastModified { get; set; }
      
        public virtual Address Address { get; set; }
        public virtual ProviderType ProviderType { get; set; }
        public virtual Specialty Specialty { get; set; }
        public virtual ICollection<EncounterPhysicians> EncounterPhysicians { get; set; }
    }
}

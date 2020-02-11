using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Facility
    {
        public Facility()
        {
            Encounter = new HashSet<Encounter>();
            UserFacility = new HashSet<UserFacility>();
        }

        public int FacilityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Encounter> Encounter { get; set; }
        public virtual ICollection<UserFacility> UserFacility { get; set; }
    }
}

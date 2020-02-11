using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PlaceOfServiceOutPatient
    {
        public PlaceOfServiceOutPatient()
        {
            Encounter = new HashSet<Encounter>();
        }

        public int PlaceOfServiceId { get; set; }
        public byte WiPopCode { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Encounter> Encounter { get; set; }
    }
}

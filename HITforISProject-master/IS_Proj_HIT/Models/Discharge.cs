using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Discharge
    {
        public Discharge()
        {
            Encounter = new HashSet<Encounter>();
        }

        public int DischargeId { get; set; }
        public string WiPopCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Encounter> Encounter { get; set; }
    }
}

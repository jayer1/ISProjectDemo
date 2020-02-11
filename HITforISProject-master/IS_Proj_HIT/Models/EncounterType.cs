using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class EncounterType
    {
        public EncounterType()
        {
            Encounter = new HashSet<Encounter>();
        }

        public int EncounterTypeId { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Encounter> Encounter { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PointOfOrigin
    {
        public PointOfOrigin()
        {
            Encounter = new HashSet<Encounter>();
        }

        public int PointOfOriginId { get; set; }
        public string WiPopCode { get; set; }
        public string Description { get; set; }
        public string Explaination { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Encounter> Encounter { get; set; }
    }
}

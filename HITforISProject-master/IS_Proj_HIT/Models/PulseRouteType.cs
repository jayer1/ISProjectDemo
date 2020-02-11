using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PulseRouteType
    {
        public PulseRouteType()
        {
            Pcarecord = new HashSet<Pcarecord>();
        }

        public int PulseRouteTypeId { get; set; }
        public string PulseRouteTypeName { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Pcarecord> Pcarecord { get; set; }
    }
}

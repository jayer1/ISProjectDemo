using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class TempRouteType
    {
        public TempRouteType()
        {
            Pcarecord = new HashSet<Pcarecord>();
        }

        public int TempRouteTypeId { get; set; }
        public string TempRouteTypeName { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Pcarecord> Pcarecord { get; set; }
    }
}

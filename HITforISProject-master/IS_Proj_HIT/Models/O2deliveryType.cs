using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class O2deliveryType
    {
        public O2deliveryType()
        {
            Pcarecord = new HashSet<Pcarecord>();
        }

        public int O2deliveryTypeId { get; set; }
        public string O2deliveryTypeName { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Pcarecord> Pcarecord { get; set; }
    }
}

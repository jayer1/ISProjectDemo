using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PainScaleType
    {
        public PainScaleType()
        {
            Pcarecord = new HashSet<Pcarecord>();
        }

        public int PainScaleTypeId { get; set; }
        public string PainScaleTypeName { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Pcarecord> Pcarecord { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class ProviderType
    {
        public ProviderType()
        {
            Physician = new HashSet<Physician>();
        }

        public int ProviderTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Physician> Physician { get; set; }
    }
}

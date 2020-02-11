using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PaymentSource
    {
        public PaymentSource()
        {
            Insurance = new HashSet<Insurance>();
        }

        public int PaymentSourceId { get; set; }
        public string WiPopCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Insurance> Insurance { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PaymentPlan
    {
        public PaymentPlan()
        {
            Insurance = new HashSet<Insurance>();
        }

        public int PaymentPlanId { get; set; }
        public string WiPopCode { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Insurance> Insurance { get; set; }
    }
}

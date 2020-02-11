using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Encounter = new HashSet<Encounter>();
        }

        public long PaymentId { get; set; }
        public int PrimaryInsuranceId { get; set; }
        public int SecondaryInsuranceId { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Insurance PrimaryInsurance { get; set; }
        public virtual Insurance SecondaryInsurance { get; set; }
        public virtual ICollection<Encounter> Encounter { get; set; }
    }
}

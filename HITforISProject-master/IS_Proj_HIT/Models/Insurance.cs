using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Insurance
    {
        public Insurance()
        {
            PaymentPrimaryInsurance = new HashSet<Payment>();
            PaymentSecondaryInsurance = new HashSet<Payment>();
        }

        public int InsuranceId { get; set; }
        public string Subscriber { get; set; }
        public string GroupName { get; set; }
        public int PaymentSourceId { get; set; }
        public int PaymentPlanId { get; set; }
        public string InsuranceName { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Address Address { get; set; }
        public virtual PaymentPlan PaymentPlan { get; set; }
        public virtual PaymentSource PaymentSource { get; set; }
        public virtual ICollection<Payment> PaymentPrimaryInsurance { get; set; }
        public virtual ICollection<Payment> PaymentSecondaryInsurance { get; set; }
    }
}

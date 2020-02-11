using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PatientContactDetails
    {
        public long PatientContactId { get; set; }
        public string Mrn { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string EmailAddress { get; set; }
        public int? MailingAddressId { get; set; }
        public int ResidenceAddressId { get; set; }
        public int PreferredModeOfContact { get; set; }
        public int PreferredTimeToContact { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Address MailingAddress { get; set; }
        public virtual Patient MrnNavigation { get; set; }
        public virtual PreferredModeOfContact PreferredModeOfContactNavigation { get; set; }
        public virtual PreferredContactTime PreferredTimeToContactNavigation { get; set; }
        public virtual Address ResidenceAddress { get; set; }
    }
}

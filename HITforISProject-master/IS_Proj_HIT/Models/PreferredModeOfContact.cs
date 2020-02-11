using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PreferredModeOfContact
    {
        public PreferredModeOfContact()
        {
            PatientContactDetails = new HashSet<PatientContactDetails>();
        }

        public int ModeOfContactId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PatientContactDetails> PatientContactDetails { get; set; }
    }
}

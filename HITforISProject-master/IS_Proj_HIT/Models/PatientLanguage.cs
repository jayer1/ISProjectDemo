using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PatientLanguage
    {
        public short LanguageId { get; set; }
        public string Mrn { get; set; }
        public byte LanguagePreference { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Language Language { get; set; }
        public virtual Patient MrnNavigation { get; set; }
    }
}

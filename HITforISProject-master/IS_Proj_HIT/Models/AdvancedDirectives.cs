using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class AdvancedDirectives
    {
        public AdvancedDirectives()
        {
            PatientAdvancedDirectives = new HashSet<PatientAdvancedDirectives>();
        }

        public short AdvancedDirectiveId { get; set; }

        public virtual ICollection<PatientAdvancedDirectives> PatientAdvancedDirectives { get; set; }
    }
}

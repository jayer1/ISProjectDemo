using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Reaction
    {
        public Reaction()
        {
            PatientAllergy = new HashSet<PatientAllergy>();
        }

        public int ReactionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PatientAllergy> PatientAllergy { get; set; }
    }
}

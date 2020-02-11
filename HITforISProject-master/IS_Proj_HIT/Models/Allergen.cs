using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Allergen
    {
        public Allergen()
        {
            PatientAllergy = new HashSet<PatientAllergy>();
        }

        public int AllergenId { get; set; }
        public string AllergenName { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PatientAllergy> PatientAllergy { get; set; }
    }
}

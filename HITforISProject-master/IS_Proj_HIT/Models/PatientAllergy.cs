using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PatientAllergy
    {
        public long PatientAllergyId { get; set; }
        public int? AllergenId { get; set; }
        public int? ReactionId { get; set; }
        public DateTime LastModified { get; set; }
        public long PatientAlertId { get; set; }

        public virtual Allergen Allergen { get; set; }
        public virtual PatientAlerts PatientAlert { get; set; }
        public virtual Reaction Reaction { get; set; }
    }
}

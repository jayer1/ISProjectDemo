using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Relationship
    {
        public Relationship()
        {
            PatientEmergencyContact = new HashSet<PatientEmergencyContact>();
        }

        public int RelationshipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PatientEmergencyContact> PatientEmergencyContact { get; set; }
    }
}

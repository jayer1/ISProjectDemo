using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class Race
    {
        public Race()
        {
            PatientRace = new HashSet<PatientRace>();
        }

        public byte RaceId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PatientRace> PatientRace { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class CareSystemAssessment
    {
        public int CareSystemAssessmentId { get; set; }
        public int Pcaid { get; set; }
        public int CareSystemAssessmentTypeId { get; set; }
        public bool WdlEx { get; set; }
        public string CareSystemComment { get; set; }
        public DateTime DateCareSystemAdded { get; set; }
        public DateTime LastModified { get; set; }

        public virtual CareSystemAssessmentType CareSystemAssessmentType { get; set; }
        public virtual Pcarecord Pca { get; set; }
    }
}

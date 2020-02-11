using System;
using System.Collections.Generic;

namespace IS_Proj_HIT.Models
{
    public partial class PcacommentType
    {
        public PcacommentType()
        {
            Pcacomment = new HashSet<Pcacomment>();
        }

        public int PcacommentTypeId { get; set; }
        public string PcacommentTypeName { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Pcacomment> Pcacomment { get; set; }
    }
}

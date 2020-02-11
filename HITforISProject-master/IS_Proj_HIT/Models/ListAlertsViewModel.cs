using IS_Proj_HIT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_Proj_HIT.Models
{
    public class ListAlertsViewModel
    {
        public IEnumerable<PatientAlerts> PatientAlerts { get; set; }
        public IEnumerable<AlertType> AlertType { get; set; }

        //public IEnumerable<PatientFallRisks> FallRisk { get; set; }
        public string Mrn { get; set; }

        public int AlertId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}

using IS_Proj_HIT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_Proj_HIT.ViewModels
{
    public class AlertsViewModel
    {
        // from PatientAlerts
        public long PatientAlertId { get; set; }
        public int? AlertTypeId { get; set; }
        public string Mrn { get; set; }
        public DateTime LastModified { get; set; }
        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }

        // from PatientRestrictions
        public short RestrictionTypeId { get; set; }

        // from PatientFallRisks
        public long PatientFallRiskId { get; set; }
        public byte FallRiskId { get; set; }

        // from Restrictions
        public short RestrictionId { get; set; }
        public string Name { get; set; }

        // from PatientAllergy
        public long PatientAllergyId { get; set; }
        public int? AllergenId { get; set; }
        public int? ReactionId { get; set; }

        // Search field added
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public PatientFallRisks PatientFallRisk { get; set; }

        public IEnumerable<FallRisks> FallRisks { get; set; }

        public IEnumerable<Allergen> AllergensCollection { get; set; }

        public IEnumerable<PatientAllergy> PatientAllergies { get; set; }
    }
}

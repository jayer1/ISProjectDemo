using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS_Proj_HIT.Models
{
    public partial class PatientAlerts
    {
        public PatientAlerts()
        {
            EncounterAlerts = new HashSet<EncounterAlerts>();
            PatientAdvancedDirectives = new HashSet<PatientAdvancedDirectives>();
            PatientAllergy = new HashSet<PatientAllergy>();
            PatientClinicalReminders = new HashSet<PatientClinicalReminders>();
            PatientFallRisks = new HashSet<PatientFallRisks>();
            PatientRestrictions = new HashSet<PatientRestrictions>();
        }

        public long PatientAlertId { get; set; }
        public int? AlertTypeId { get; set; }
        public string Mrn { get; set; }
        public DateTime LastModified { get; set; }
        public bool? IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }

        public virtual AlertType AlertType { get; set; }
        public virtual Patient MrnNavigation { get; set; }
        public virtual ICollection<EncounterAlerts> EncounterAlerts { get; set; }
        public virtual ICollection<PatientAdvancedDirectives> PatientAdvancedDirectives { get; set; }
        public virtual ICollection<PatientAllergy> PatientAllergy { get; set; }
        public virtual ICollection<PatientClinicalReminders> PatientClinicalReminders { get; set; }
        public virtual ICollection<PatientFallRisks> PatientFallRisks { get; set; }
        public virtual ICollection<PatientRestrictions> PatientRestrictions { get; set; }
    }
}

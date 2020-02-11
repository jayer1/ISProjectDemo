using IS_Proj_HIT.Models;
using IS_Proj_HIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace isprojectHiT.Models
{
    public class EFWCTCHealthSystemRepository : IWCTCHealthSystemRepository
    {
        private WCTCHealthSystemContext context;
        public EFWCTCHealthSystemRepository(WCTCHealthSystemContext ctx)
        {
            context = ctx;
        }

        public IQueryable<AdmitType> AdmitTypes => context.AdmitType;
        public IQueryable<Ethnicity> Ethnicities => context.Ethnicity;
        public IQueryable<Gender> Genders => context.Gender;

        public IQueryable<AspNetUsers> AspNetUsers => context.AspNetUsers;

        public IQueryable<Departments> Departments => context.Departments;
        public IQueryable<EncounterType> EncounterTypes => context.EncounterType;

        public IQueryable<Discharge> Discharges => context.Discharge;
        public IQueryable<Sex> Sexes => context.Sex;

        public IQueryable<Patient> Patients => context.Patient;
        public IQueryable<PlaceOfServiceOutPatient> PlaceOfService => context.PlaceOfServiceOutPatient;
        public IQueryable<PointOfOrigin> PointOfOrigin => context.PointOfOrigin;

        public IQueryable<Religion> Religions => context.Religion;

        public IQueryable<MaritalStatus> MaritalStatuses => context.MaritalStatus;

        public IQueryable<PatientContactDetails> PatientContactDetails => context.PatientContactDetails;

        public IQueryable<PatientAlerts> PatientAlerts => context.PatientAlerts;

        public IQueryable<AlertType> AlertTypes => context.AlertType;
        public IQueryable<PatientRestrictions> PatientRestrictions => context.PatientRestrictions;

        public IQueryable<Employment> Employments => context.Employment;
        public IQueryable<Encounter> Encounters => context.Encounter;

        public IQueryable<FallRisks> FallRisks => context.FallRisks;
        public IQueryable<Restrictions> Restrictions => context.Restrictions;

        public IQueryable<PatientFallRisks> PatientFallRisks => context.PatientFallRisks;


        public IQueryable<Allergen> Allergens => context.Allergen;

        public IQueryable<Reaction> Reactions => context.Reaction;

        public IQueryable<PatientAllergy> PatientAllergy => context.PatientAllergy;
        public IQueryable<EncounterPhysicians> EncounterPhysicians => context.EncounterPhysicians;
        public IQueryable<Facility> Facilities => context.Facility;
        public IQueryable<Physician> Physicians => context.Physician;
        public IQueryable<PhysicianRole> PhysicianRoles => context.PhysicianRole;
        public IQueryable<UserTable> UserTables => context.UserTable;


        public void AddEmployment(Employment employment)
        {
            context.Add(employment);
            context.SaveChanges();
        }

        public void AddEncounter(Encounter encounter)
        {
            context.Add(encounter);
            context.SaveChanges();
        }

        public void AddPatient(Patient patient)
        {
            context.Add(patient);
            context.SaveChanges();
        }

        public void DeletePatient(Patient patient)
        {
            context.Remove(patient);
            context.SaveChanges();
        }

        public void DeleteEncounter(Encounter encounter)
        {
            context.Remove(encounter);
            context.SaveChanges();
        }

        public void AddUser(UserTable userTable)
        {
            context.Add(userTable);
            context.SaveChanges();
        }

        public void DeleteUser(UserTable userTable)
        {
            context.Remove(userTable);
            context.SaveChanges();
        }

        public void EditUser(UserTable userTable)
        {
            context.Update(userTable);
            context.SaveChanges();
        }

        public void EditPatient(Patient patient)
        {
            /*if (patient.Mrn == 0)
            {
                context.Patient.Add(patient);
            }
            else
            {*/
            context.Update(patient);
            //}

            context.SaveChanges();
        }

        public void EditAlert(PatientAlerts alert)
        {
            context.Update(alert);
            context.SaveChanges();
        }

        public void EditEncounter(Encounter encounter)
        {
            context.Update(encounter);

            context.SaveChanges();
        }

        public void AddAlert(AlertsViewModel alert)
        {
            PatientAlerts pa = new PatientAlerts();
            pa.AlertTypeId = alert.AlertTypeId;
            pa.PatientAlertId = alert.PatientAlertId;
            pa.Mrn = alert.Mrn;
            pa.LastModified = alert.LastModified;
            pa.StartDate = alert.StartDate;
            pa.EndDate = alert.EndDate;
            pa.Comments = alert.Comments;
            //context.PatientAlerts.Add(pa);
            context.Attach(pa);
            context.SaveChanges();
            long patientAlertid = pa.PatientAlertId;
            int? alertTypeid = pa.AlertTypeId;

            // Based on the alertTypeid above, decide which db table to save to...
            if (alertTypeid == 5)
            {
                PatientFallRisks pfr = new PatientFallRisks();
                pfr.FallRiskId = alert.FallRiskId;
                pfr.PatientAlertId = patientAlertid;
                pfr.LastModified = alert.LastModified;
                context.Attach(pfr);
                context.SaveChanges();
            }
            else if (alertTypeid == 3)
            {


                PatientRestrictions pr = new PatientRestrictions();
                pr.RestrictionTypeId = alert.RestrictionTypeId;
                pr.PatientAlertId = patientAlertid;
                pr.LastModified = alert.LastModified;
                context.PatientRestrictions.Add(pr);
                context.SaveChanges();
            }
            else if (alertTypeid == 4)
            {
                PatientAllergy pall = new PatientAllergy();
                pall.AllergenId = alert.AllergenId;
                pall.ReactionId = alert.ReactionId;
                pall.PatientAlertId = patientAlertid;
                pall.LastModified = alert.LastModified;
                context.PatientAllergy.Add(pall);
                context.SaveChanges();
            }
            else
            {
                //do nothing else (Advanced Directive and Clinical Reminder only use PatientAlerts table)
            }
        }

    }
}

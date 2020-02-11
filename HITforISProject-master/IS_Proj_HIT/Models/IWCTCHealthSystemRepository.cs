using IS_Proj_HIT.Models;
using IS_Proj_HIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isprojectHiT.Models
{
    public interface IWCTCHealthSystemRepository
    {
        IQueryable<AdmitType> AdmitTypes { get; }
        IQueryable<Ethnicity> Ethnicities { get; }
        IQueryable<Gender> Genders { get; }
        IQueryable<Discharge> Discharges { get; }
        IQueryable<Departments> Departments { get; }
        IQueryable<EncounterType> EncounterTypes { get; }
        IQueryable<Sex> Sexes { get; }
        IQueryable<Religion> Religions { get; }
        IQueryable<MaritalStatus> MaritalStatuses { get; }
        IQueryable<Patient> Patients { get; }
        IQueryable<PlaceOfServiceOutPatient> PlaceOfService { get; }
        IQueryable<PointOfOrigin> PointOfOrigin { get; }
        IQueryable<Employment> Employments { get; }
        IQueryable<Encounter> Encounters { get; }
        IQueryable<EncounterPhysicians> EncounterPhysicians { get; }
        IQueryable<Facility> Facilities { get; }
        IQueryable<PatientContactDetails> PatientContactDetails { get; }
        IQueryable<Physician> Physicians { get; }
        IQueryable<PhysicianRole> PhysicianRoles { get; }

        IQueryable<PatientAlerts> PatientAlerts { get; }
        IQueryable<AlertType> AlertTypes { get; }
        IQueryable<PatientRestrictions> PatientRestrictions { get; }
        IQueryable<Restrictions> Restrictions { get; }
        IQueryable<PatientFallRisks> PatientFallRisks { get; }
        IQueryable<FallRisks> FallRisks { get; }
        IQueryable<Allergen> Allergens { get; }
        IQueryable<Reaction> Reactions { get; }
        IQueryable<PatientAllergy> PatientAllergy { get; }
        IQueryable<UserTable> UserTables { get; }


        void AddPatient(Patient patient);
        void DeletePatient(Patient patient);
        void EditPatient(Patient patient);
        void EditEncounter(Encounter encounter);
        void DeleteEncounter(Encounter encounter);

        void AddAlert(AlertsViewModel alert);
        void EditAlert(PatientAlerts alert);
        void AddEmployment(Employment employment);
        void AddEncounter(Encounter encounter);

        void AddUser(UserTable userTable);
        void DeleteUser(UserTable userTable);
        void EditUser(UserTable userTable);
    }
}

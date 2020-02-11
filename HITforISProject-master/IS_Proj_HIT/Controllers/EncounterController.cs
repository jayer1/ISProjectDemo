using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IS_Proj_HIT.Models;
using IS_Proj_HIT.Models.ViewModels;
using isprojectHiT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using IS_Proj_HIT.Extensions.Alerts;
using IS_Proj_HIT.ViewModels;
using System.Diagnostics;

namespace IS_Proj_HIT.Controllers
{
    public class EncounterController : Controller
    {
        private IWCTCHealthSystemRepository repository;
        public int PageSize = 8;
        public EncounterController(IWCTCHealthSystemRepository repo) => repository = repo;

        public ViewResult Index(string filter, int encounterPage = 1)

        {
            var patientEncounters = repository.Encounters
                .Join(repository.Patients,
                encounter => encounter.Mrn,
                patient => patient.Mrn,
                (encounter, patient) => new
                {
                    Mrn = encounter.Mrn,
                    EncounterId = encounter.EncounterId,
                    AdmitDateTime = encounter.AdmitDateTime,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    FacilityName = repository.Facilities.FirstOrDefault(b => b.FacilityId == encounter.FacilityId).Name,
                    DischargeDateTime = ((encounter.DischargeDateTime == null) ? "Patient has not yet been discharged" : encounter.DischargeDateTime.ToString())

                }).ToList();

            if (filter == "CheckedIn")
            {
                var tempList = patientEncounters;
                foreach (var e in patientEncounters.ToList())
                {
                    if (e.DischargeDateTime != "Patient has not yet been discharged")
                    {
                        tempList.Remove(e);
                    }
                }
                patientEncounters = tempList;
            }

            List<EncounterPatientViewModel> viewPatientEncounters = new List<EncounterPatientViewModel>();
            for(int i = 0; i < patientEncounters.Count(); i++)
            {
                EncounterPatientViewModel thisPatientEncounter = new EncounterPatientViewModel(patientEncounters[i].Mrn,
                    patientEncounters[i].EncounterId, patientEncounters[i].AdmitDateTime,
                    patientEncounters[i].FirstName, patientEncounters[i].LastName, patientEncounters[i].FacilityName,
                    patientEncounters[i].DischargeDateTime);
                viewPatientEncounters.Add(thisPatientEncounter);
            }
            return View(viewPatientEncounters);
        }

        public ViewResult PatientEncounters(string patientMRN)
        {
            var patientEncounters = repository.Encounters
                .Join(repository.Patients,
                encounter => encounter.Mrn,
                patient => patient.Mrn,
                (encounter, patient) => new
                {
                    Mrn = encounter.Mrn,
                    EncounterId = encounter.EncounterId,
                    AdmitDateTime = encounter.AdmitDateTime,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    FacilityName = repository.Facilities.FirstOrDefault(b => b.FacilityId == encounter.FacilityId).Name,
                    DischargeDateTime = ((encounter.DischargeDateTime == null) ? "Patient has not yet been discharged" : encounter.DischargeDateTime.ToString())

                })
                .Where(patientEncounterMRN => patientEncounterMRN.Mrn == patientMRN).ToList();
            List<EncounterPatientViewModel> viewPatientEncounters = new List<EncounterPatientViewModel>();
            for (int i = 0; i < patientEncounters.Count(); i++)
            {
                EncounterPatientViewModel thisPatientEncounter = new EncounterPatientViewModel(patientEncounters[i].Mrn,
                    patientEncounters[i].EncounterId, patientEncounters[i].AdmitDateTime,
                    patientEncounters[i].FirstName, patientEncounters[i].LastName, patientEncounters[i].FacilityName,
                    patientEncounters[i].DischargeDateTime);
                viewPatientEncounters.Add(thisPatientEncounter);
            }
            return View(viewPatientEncounters);
        }

        // Deletes Encounter
        public IActionResult DeleteEncounter(long encounterId)
        {
            var encounter = repository.Encounters.FirstOrDefault(b => b.EncounterId == encounterId);
            repository.DeleteEncounter(encounter);
            return RedirectToAction("Index");
        }


        // Displays the Edit Encounter page
        public IActionResult EditEncounter(long encounterId, bool isPatientEncounter)
        {
            ViewBag.isPatientEncounter = isPatientEncounter;
            ViewBag.EncounterId = repository.Encounters.FirstOrDefault(b => b.EncounterId == encounterId).EncounterId;
            DateTime encounterAdmitDateTime = repository.Encounters.FirstOrDefault(b => b.EncounterId == encounterId).AdmitDateTime;
            ViewBag.AdmitDateTime = "" + encounterAdmitDateTime.Year + "-" +
                ((encounterAdmitDateTime.Month < 10) ? "0" + encounterAdmitDateTime.Month.ToString() : encounterAdmitDateTime.Month.ToString()) + "-" +
                ((encounterAdmitDateTime.Day < 10) ? "0" + encounterAdmitDateTime.Day.ToString() : encounterAdmitDateTime.Day.ToString()) + "T" +
                ((encounterAdmitDateTime.Hour < 10) ? "0" + encounterAdmitDateTime.Hour.ToString() : encounterAdmitDateTime.Hour.ToString()) + ":" +
                ((encounterAdmitDateTime.Minute < 10) ? "0" + encounterAdmitDateTime.Minute.ToString() : encounterAdmitDateTime.Minute.ToString());
            ViewBag.EncounterMRN = repository.Encounters.FirstOrDefault(b => b.EncounterId == encounterId).Mrn;
            string encounterMrn = ViewBag.EncounterMRN;
            ViewBag.LastModified = DateTime.Today.AddYears(-1);
            ViewBag.PatientFirstName = repository.Patients.FirstOrDefault(b => b.Mrn == encounterMrn).FirstName;
            ViewBag.PatientMiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == encounterMrn).MiddleName;
            ViewBag.PatientLastName = repository.Patients.FirstOrDefault(b => b.Mrn == encounterMrn).LastName;
            ViewBag.PatientDob = repository.Patients.FirstOrDefault(b => b.Mrn == encounterMrn).Dob;
            DateTime now = DateTime.Now;
            TimeSpan pAge = now.Subtract(ViewBag.PatientDob);
            if (pAge.Days > 365)
            {
                ViewBag.CurrentPatientAge = (byte)(pAge.Days / 365);
                ViewBag.PatientAge = ViewBag.CurrentPatientAge + " Years";
            }
            else
            {
                ViewBag.CurrentPatientAge = 0;
                ViewBag.PatientAge = pAge.Days + " Days";
            }
            //If you wanted to get the tool tips, you'd need to do this:
            //repository.AdmitTypes.FirstOrDefault(b => b.AdmitTypeId == id).Explaination
            //can also probably make these queries into a function if you can figure out how to make the respository types generic
            var queryAdmitTypes = repository.AdmitTypes.Select(at => new { at.AdmitTypeId, at.Description });
            queryAdmitTypes = queryAdmitTypes.OrderBy(n => n.Description);
            ViewBag.AdmitTypes = new SelectList(queryAdmitTypes.AsEnumerable(), "AdmitTypeId", "Description", 0);

            var queryDepartments = repository.Departments.Select(dep => new { dep.DepartmentId, dep.Name });
            queryDepartments = queryDepartments.OrderBy(n => n.Name);
            ViewBag.Departments = new SelectList(queryDepartments.AsEnumerable(), "DepartmentId", "Name", 0);

            var queryDischarges = repository.Discharges.Select(dis => new { dis.DischargeId, dis.Name });
            queryDischarges = queryDischarges.OrderBy(n => n.Name);
            ViewBag.Discharges = new SelectList(queryDischarges.AsEnumerable(), "DischargeId", "Name", 0);

            var queryEncounterTypes = repository.EncounterTypes.Select(ent => new { ent.EncounterTypeId, ent.Name });
            queryEncounterTypes = queryEncounterTypes.OrderBy(n => n.Name);
            ViewBag.EncounterTypes = new SelectList(queryEncounterTypes.AsEnumerable(), "EncounterTypeId", "Name", 0);

            var queryPlacesOfService = repository.PlaceOfService.Select(pos => new { pos.PlaceOfServiceId, pos.Description });
            queryPlacesOfService = queryPlacesOfService.OrderBy(n => n.Description);
            ViewBag.PlacesOfService = new SelectList(queryPlacesOfService.AsEnumerable(), "PlaceOfServiceId", "Description", 0);

            var queryPointsOfOrigin = repository.PointOfOrigin.Select(poo => new { poo.PointOfOriginId, poo.Description });
            queryPointsOfOrigin = queryPointsOfOrigin.OrderBy(n => n.Description);
            ViewBag.PointsOfOrigin = new SelectList(queryPointsOfOrigin.AsEnumerable(), "PointOfOriginId", "Description", 0);

            var queryFacility = repository.Facilities.Select(fac => new { fac.FacilityId, fac.Name });
            queryFacility = queryFacility.OrderBy(n => n.Name);
            ViewBag.Facility = new SelectList(queryFacility.AsEnumerable(), "FacilityId", "Name", 0);

            var queryEncounterPhysicians = repository.EncounterPhysicians.Select(EnP => new { EnP.EncounterPhysiciansId, Name = (repository.Physicians.FirstOrDefault(b => b.PhysicianId == EnP.PhysicianId).FirstName + " " + repository.Physicians.FirstOrDefault(b => b.PhysicianId == EnP.PhysicianId).LastName) });
            queryEncounterPhysicians = queryEncounterPhysicians.OrderBy(n => n.Name);
            ViewBag.EncounterPhysicians = new SelectList(queryEncounterPhysicians.AsEnumerable(), "EncounterPhysiciansId", "Name", 0);

            return View(repository.Encounters.FirstOrDefault(e => e.EncounterId == encounterId));
        }

        // Save edits to patient record from Edit Patients page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEncounter(Encounter model, string id)
        {
            if (ModelState.IsValid)
            {
                model.LastModified = @DateTime.Now;
                repository.EditEncounter(model);
                Debug.WriteLine("find me! " + Request);
                return Redirect("/Encounter");
            }
            return View();


        }


        // Save edits to patient record from Edit a specific Patients encounters page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPatientEncounter(Encounter model, string id)
        {
            if (ModelState.IsValid)
            {
                model.LastModified = @DateTime.Now;
                repository.EditEncounter(model);
                string myUrl = "/Encounter/PatientEncounters?patientMRN=" + model.Mrn;
                return Redirect(myUrl);
            }
            return View();


        }
    }

}

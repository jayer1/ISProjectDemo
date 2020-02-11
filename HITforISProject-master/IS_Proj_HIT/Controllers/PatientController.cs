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
using System.Globalization;
using PagedList;
using PagedList.Mvc;

namespace IS_Proj_HIT.Controllers
{
    public class PatientController : Controller
    {
        private IWCTCHealthSystemRepository repository;
        public int PageSize = 8;
        public PatientController(IWCTCHealthSystemRepository repo) => repository = repo;

        // Displays list of patients
        //public ViewResult Index(string firstname, int patientPage = 1) => View(new ListPatientsViewModel
        //{
        //    Patients = repository.Patients
        //        .Include(p => p.Religion)
        //        .Include(p => p.Gender)
        //        .Include(p => p.Ethnicity)
        //        .Include(p => p.MaritalStatus)
        //        .OrderBy(p => p.FirstName)
        //        .Skip((patientPage - 1) * PageSize)
        //        .Take(PageSize),
        //    PagingInfo = new PagingInfo
        //    {
        //        CurrentPage = patientPage,
        //        ItemsPerPage = PageSize,
        //        TotalItems = repository.Patients.Count()
        //    }
        //});

        public ActionResult Index(string searchLast, string searchFirst, string searchSSN, string searchMRN, DateTime searchDOB, DateTime searchDOBBefore, string sortOrder)
        {
            // Put in a wildcard if user didn't search on these fields
            if (searchLast == null)
            {
                searchLast = " ";

            }
            if (searchFirst == null)
            {
                searchFirst = " ";
            }
            if (searchSSN == null)
            {
                searchSSN = " ";
            }
            if (searchMRN == null)
            {
                searchMRN = " ";
            }


            if (searchDOB.GetHashCode() == 0)
            {
                searchDOB = new DateTime(1898, 1, 1);
            }
            if (searchDOBBefore.GetHashCode() == 0)
            {
                searchDOBBefore = new DateTime(2030, 1, 1);
            }

            var patients = repository.Patients
                    .Include(p => p.Religion)
                    .Include(p => p.Gender)
                    .Include(p => p.Ethnicity)
                    .Include(p => p.MaritalStatus)
                    .Where(p => p.LastName.Contains(searchLast)
                        && p.FirstName.Contains(searchFirst)
                        && p.Ssn.Contains(searchSSN)
                        && p.Mrn.Contains(searchMRN)
                        && p.Dob >= searchDOB
                        && p.Dob <= searchDOBBefore);

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.MrnSortParm = sortOrder == "mrn" ? "mrn_desc" : "mrn";
            ViewBag.DobSortParm = sortOrder == "dob" ? "dob_desc" : "dob";

            ViewBag.sortOrder = sortOrder;
            ViewBag.searchLast = searchLast;
            ViewBag.searchFirst = searchFirst;
            ViewBag.searchSSN = searchSSN;
            ViewBag.searchDOB = searchDOB;
            ViewBag.searchDOBBefore = searchDOBBefore;

            switch (sortOrder)
            {
                case "mrn":
                    patients = patients.OrderBy(p => p.Mrn);
                    break;
                case "mrn_desc":
                    patients = patients.OrderByDescending(p => p.Mrn);
                    break;
                case "dob":
                    patients = patients.OrderBy(p => p.Dob);
                    break;
                case "dob_desc":
                    patients = patients.OrderByDescending(p => p.Dob);
                    break;
                case "name_desc":
                    patients = patients.OrderByDescending(p => p.LastName);
                    break;
                default:
                    patients = patients.OrderBy(p => p.LastName);
                    ViewBag.sortOrder = "name";
                    break;
            }

            return View(new ListPatientsViewModel
            {
                Patients = patients
            });

        }



        // Displays the Add Patient entry page
        public ActionResult AddPatient()
        {

            //Run stored procedure from SQL database to generate the MRN number
            using (var context = new WCTCHealthSystemContext())
            {
                var data = context.Patient.FromSql("EXECUTE dbo.GetNextMRN");
                ViewBag.MRN = data.FirstOrDefault().Mrn;

            }

            ViewBag.LastModified = DateTime.Today.AddYears(-1);


            // Do it this way if you need to have nothing selected as default
            var query = repository.Religions.Select(r => new { r.ReligionId, r.Name });
            query = query.OrderBy(r => r.Name);
            ViewBag.Religions = new SelectList(query.AsEnumerable(), "ReligionId", "Name", 0);

            var querySex = repository.Sexes.Select(r => new { r.SexId, r.Name });
            querySex = querySex.OrderBy(r => r.Name);
            ViewBag.Sexes = new SelectList(querySex.AsEnumerable(), "SexId", "Name", 0);

            var queryGender = repository.Genders.Select(r => new { r.GenderId, r.Name });
            queryGender = queryGender.OrderBy(r => r.Name);
            ViewBag.Gender = new SelectList(queryGender.AsEnumerable(), "GenderId", "Name", 0);

            var queryEthnicity = repository.Ethnicities.Select(r => new { r.EthnicityId, r.Name });
            queryEthnicity = queryEthnicity.OrderBy(r => r.Name);
            ViewBag.Ethnicity = new SelectList(queryEthnicity.AsEnumerable(), "EthnicityId", "Name", 0);

            var queryMaritalStatus = repository.MaritalStatuses.Select(r => new { r.MaritalStatusId, r.Name });
            queryMaritalStatus = queryMaritalStatus.OrderBy(r => r.Name);
            ViewBag.MaritalStatus = new SelectList(queryMaritalStatus.AsEnumerable(), "MaritalStatusId", "Name", 0);

            //var queryEmployment = repository.Employment.Select(r => new { r.MaritalStatusId, r.Name });
            //ViewBag.Employment = new SelectList(queryEmployment.AsEnumerable(), "MaritalStatusId", "Name", 0);

            //ViewBag.Employment = repository.Employments.Select(e =>
            //                    new SelectListItem
            //                    {
            //                        Value = e.EmploymentId.ToString(),
            //                        Text = (e.EmployerName + " - " + e.Occupation).ToString()
            //                    }).ToList();
            return View();

        }


        // Click Create button on Add Patient page adds new patient from Add Patient page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPatient(Patient model)
        {
            //ViewBag.LastModified = DateTime.Today.AddYears(-1);
            if (ModelState.IsValid)
            {
                if (repository.Patients.Any(p => p.Mrn == model.Mrn))
                {
                    ModelState.AddModelError("", "MRN Id must be unique");
                }
                else
                {
                    model.LastModified = @DateTime.Now;
                    repository.AddPatient(model);
                    TempData["msg"] = "A new patient was successfully created.";
                    string myUrl = "Details/" + model.Mrn;
                    return Redirect(myUrl);

                    //return RedirectToAction("Index");
                    // Alternate returns
                    //return Unauthorized();
                    //var result = new OkObjectResult(new { message = "200 OK Computer", currentDate = DateTime.Now });
                    //return result;
                    //return File("~/img/WCTMC Logo.jpg", "image/jpg");
                    //return File("~/pdfs/Bike_Ride.pdf", "application/pdf");
                    //return Content("Here's the ContentResult message.");
                }
            }
            return View();
        }


        // Deletes Patient
        public IActionResult DeletePatient(string id)
        {
            ViewBag.PatientAlertExists = repository.PatientAlerts.FirstOrDefault(b => b.Mrn == id);
            if (ViewBag.PatientAlertExists != null)
            {
                TempData["msg1"] = "You cannot delete a patient with patient alerts.";
                return RedirectToRoute(new
                {
                    controller = "Patient",
                    action = "Details",
                    ID = id

                });

            }
            else
            {
                TempData["msg1"] = "The selected patient was deleted.";
                repository.DeletePatient(repository.Patients.FirstOrDefault(b => b.Mrn == id));
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"

                });
            }
            //return RedirectToAction("Index", "Home");

        }


        public IActionResult AddEncounter(string id)
        {
            ViewBag.EncounterMRN = repository.Patients.FirstOrDefault(b => b.Mrn == id).Mrn;
            ViewBag.LastModified = DateTime.Today.AddYears(-1);
            ViewBag.PatientFirstName = repository.Patients.FirstOrDefault(b => b.Mrn == id).FirstName;
            ViewBag.PatientMiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == id).MiddleName;
            ViewBag.PatientLastName = repository.Patients.FirstOrDefault(b => b.Mrn == id).LastName;
            ViewBag.PatientDob = repository.Patients.FirstOrDefault(b => b.Mrn == id).Dob;
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
            var queryAdmitTypes = repository.AdmitTypes.Select(at => new { at.AdmitTypeId, at.Description });
            queryAdmitTypes = queryAdmitTypes.OrderBy(n => n.Description);
            ViewBag.AdmitTypes = new SelectList(queryAdmitTypes.AsEnumerable(), "AdmitTypeId", "Description", 0);

            var queryDepartments = repository.Departments.Select(dep => new { dep.DepartmentId, dep.Name });
            queryDepartments = queryDepartments.OrderBy(n => n.Name);
            ViewBag.Departments = new SelectList(queryDepartments.AsEnumerable(), "DepartmentId", "Name", 0);

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
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEncounter(Encounter model)
        {
            if (ModelState.IsValid)
            {
                if (repository.Encounters.Any(p => p.EncounterId == model.EncounterId))
                {
                    ModelState.AddModelError("", "Encounter Id must be unique");
                }
                else
                {
                    Debug.WriteLine("find me! " + Request.Form["Facility"]);
                    model.LastModified = @DateTime.Now;
                    Debug.WriteLine("MRN: " + model.Mrn);
                    Debug.WriteLine("Facility: " + model.FacilityId);
                    Debug.WriteLine("EncounterType: " + model.EncounterTypeId);
                    repository.AddEncounter(model);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        // Displays the Edit Patient page
        public IActionResult Edit(string id)
        {
            ViewBag.myMrn = id;
            //ViewBags for Patient Banner at top of page
            ViewBag.FirstName = repository.Patients.FirstOrDefault(b => b.Mrn == id).FirstName;
            ViewBag.MiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == id).MiddleName;
            ViewBag.LastName = repository.Patients.FirstOrDefault(b => b.Mrn == id).LastName;
            ViewBag.Dob = repository.Patients.FirstOrDefault(b => b.Mrn == id).Dob;

            ViewBag.LastModified = DateTime.Today.AddYears(-1);

            var query = repository.Religions.Select(r => new { r.ReligionId, r.Name });
            query = query.OrderBy(r => r.Name);
            ViewBag.Religions = new SelectList(query.AsEnumerable(), "ReligionId", "Name", 0);

            var querySex = repository.Sexes.Select(r => new { r.SexId, r.Name });
            querySex = querySex.OrderBy(r => r.Name);
            ViewBag.Sexes = new SelectList(querySex.AsEnumerable(), "SexId", "Name", 0);

            var queryGender = repository.Genders.Select(r => new { r.GenderId, r.Name });
            queryGender = queryGender.OrderBy(r => r.Name);
            ViewBag.Gender = new SelectList(queryGender.AsEnumerable(), "GenderId", "Name", 0);

            var queryEthnicity = repository.Ethnicities.Select(r => new { r.EthnicityId, r.Name });
            queryEthnicity = queryEthnicity.OrderBy(r => r.Name);
            ViewBag.Ethnicity = new SelectList(queryEthnicity.AsEnumerable(), "EthnicityId", "Name", 0);

            var queryMaritalStatus = repository.MaritalStatuses.Select(r => new { r.MaritalStatusId, r.Name });
            queryMaritalStatus = queryMaritalStatus.OrderBy(r => r.Name);
            ViewBag.MaritalStatus = new SelectList(queryMaritalStatus.AsEnumerable(), "MaritalStatusId", "Name", 0);

            return View(repository.Patients.FirstOrDefault(p => p.Mrn == id));

        }

        // Save edits to patient record from Edit Patients page
        [HttpPost]
        [ActionName("Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient model, string id)
        {
            if (ModelState.IsValid)
            {
                model.LastModified = @DateTime.Now;
                repository.EditPatient(model);
                // I added the string id to the IActionResult above to pass in the model's Mrn
                // Then I constructed the redirect URL pointing to the Details page/id
                string myUrl = "Details/" + model.Mrn;
                return Redirect(myUrl);
            }
            return View();


        }

        // find all the encounters for a specific patient
        public IActionResult allPatientEncounters(string MRN)
        {
            string myUrl = "/Encounter/PatientEncounters?patientMRN=" + MRN;
            return Redirect(myUrl);

        }

        // Pick record to send to Details page
        public IActionResult Details(string id)
        {
            ViewBag.PatientAlertsCount = repository.PatientAlerts.Where(b => b.Mrn == id).Count();
            Debug.WriteLine("Trying to save(PatientController)"); //Look here
            ViewBag.ReligionID = repository.Patients.Include(p => p.Religion).FirstOrDefault(p => p.Mrn == id);
            ViewBag.MaritalID = repository.Patients.Include(p => p.MaritalStatus).FirstOrDefault(p => p.Mrn == id);
            ViewBag.SexID = repository.Patients.Include(p => p.Sex).FirstOrDefault(p => p.Mrn == id);
            ViewBag.GenderID = repository.Patients.Include(p => p.Gender).FirstOrDefault(p => p.Mrn == id);
            ViewBag.EthnicityID = repository.Patients.Include(p => p.Ethnicity).FirstOrDefault(p => p.Mrn == id);
            if (repository.Encounters.Where(e => e.Mrn == id).Count() > 0)
            {
                ViewBag.isThereEncounter = true;
            }
            else
            {
                ViewBag.isThereEncounter = false;
            }

            return View(repository.Patients.FirstOrDefault(p => p.Mrn == id));

        }

        //List Alerts for the currently selected MRN
        public IActionResult ListAlerts(string id, string sortOrder)
        {
            // New
            //ViewBag.CommentSortParm = String.IsNullOrEmpty(sortOrder) ? "byComments" : "byCommentsDesc";
            ViewBag.StartSortParm = sortOrder == "byStartDate" ? "byStartDateDesc" : "byStartDate";
            ViewBag.ActiveSortParm = sortOrder == "byActive" ? "byActiveDesc" : "byActive";
            //ViewBag.LastModifiedTypeSortParm = sortOrder == "byLastModified" ? "byLastModified" : "";
            ViewBag.AlertTypeSortParm = sortOrder == "byAlertType" ? "byAlertTypeDesc" : "byAlertType";

            // Existing
            ViewBag.myMrn = id;
            //ViewBags for Patient Banner at top of page
            ViewBag.FirstName = repository.Patients.FirstOrDefault(b => b.Mrn == id).FirstName;
            ViewBag.MiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == id).MiddleName;
            ViewBag.LastName = repository.Patients.FirstOrDefault(b => b.Mrn == id).LastName;
            ViewBag.Dob = repository.Patients.FirstOrDefault(b => b.Mrn == id).Dob;
            if (sortOrder == "byAlertType" && repository.PatientAlerts.Where(b => b.Mrn == id).Count() > 0)
            {
                TempData["msg"] = "Sort order is by Alert Type Ascending";
            }
            else if (sortOrder == "byAlertTypeDesc" && repository.PatientAlerts.Where(b => b.Mrn == id).Count() > 0)
            {
                TempData["msg"] = "Sort order is by Alert Type Descending";
            }
            else if (sortOrder == "byStartDate" && repository.PatientAlerts.Where(b => b.Mrn == id).Count() > 0)
            {
                TempData["msg"] = "Sort order is by Start Date Ascending";
            }

            else if (sortOrder == "byStartDateDesc" && repository.PatientAlerts.Where(b => b.Mrn == id).Count() > 0)
            {
                TempData["msg"] = "Sort order is by Start Date Descending";
            }

            else if (sortOrder == "byActive" && repository.PatientAlerts.Where(b => b.Mrn == id).Count() > 0)
            {
                TempData["msg"] = "Sort order is by Active Ascending";
            }

            else if (sortOrder == "byActiveDesc" && repository.PatientAlerts.Where(b => b.Mrn == id).Count() > 0)
            {
                TempData["msg"] = "Sort order is by Active Descending";
            }

            else
            {
                TempData["msg"] = "";
            }


            if (sortOrder == "byStartDate")
            {
                sortOrder = "";
                return View(new ListAlertsViewModel
                {
                    PatientAlerts = repository.PatientAlerts
                .Include(p => p.AlertType)
                .Where(p => p.Mrn == id)
                .OrderBy(p => p.StartDate)
                });
            }
            if (sortOrder == "byStartDateDesc")
            {
                sortOrder = "";
                return View(new ListAlertsViewModel
                {
                    PatientAlerts = repository.PatientAlerts
                .Include(p => p.AlertType)
                .Where(p => p.Mrn == id)
                .OrderByDescending(p => p.StartDate)
                });
            }

            if (sortOrder == "byAlertType")
            {
                sortOrder = "";
                return View(new ListAlertsViewModel
                {
                    PatientAlerts = repository.PatientAlerts
                .Include(p => p.AlertType)
                .Where(p => p.Mrn == id)
                .OrderBy(p => p.AlertType.Name)
                });
            }
            if (sortOrder == "byAlertTypeDesc")
            {
                sortOrder = "";
                return View(new ListAlertsViewModel
                {
                    PatientAlerts = repository.PatientAlerts
                .Include(p => p.AlertType)
                .Where(p => p.Mrn == id)
                .OrderByDescending(p => p.AlertType.Name)
                });

            }

            if (sortOrder == "byActive")
            {
                {
                    sortOrder = "";
                    return View(new ListAlertsViewModel
                    {
                        PatientAlerts = repository.PatientAlerts
                    .Include(p => p.AlertType)
                    .Where(p => p.Mrn == id)
                    .OrderBy(p => p.IsActive)
                    });

                }
            }

            if (sortOrder == "byActiveDesc")
            {
                {
                    sortOrder = "";
                    return View(new ListAlertsViewModel
                    {
                        PatientAlerts = repository.PatientAlerts
                    .Include(p => p.AlertType)
                    .Where(p => p.Mrn == id)
                    .OrderByDescending(p => p.IsActive)
                    });

                }
            }
            else
            {
                sortOrder = "";
                return View(new ListAlertsViewModel
                {
                    PatientAlerts = repository.PatientAlerts
                .Include(p => p.AlertType)
                .Where(p => p.Mrn == id)
                .OrderByDescending(p => p.LastModified)
                });
            }

        }

        public RedirectToRouteResult BackToDetails(string id) =>
        RedirectToRoute(new
        {
            controller = "Patient",
            action = "Details",
            ID = id
        });

        public RedirectToRouteResult BackToListAlerts(string id) =>
        RedirectToRoute(new
        {
            controller = "Patient",
            action = "ListAlerts",
            ID = id
        });

        //// Load page for adding patient alerts
        //public IActionResult DisplayAddAlert(string id)
        //{
        //    ViewBag.myMrn = id;
        //    ViewBag.LastModified = DateTime.Today;
        //    //ViewBags for Patient Banner at top of page
        //    ViewBag.FirstName = repository.Patients.FirstOrDefault(b => b.Mrn == id).FirstName;
        //    ViewBag.MiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == id).MiddleName;
        //    ViewBag.LastName = repository.Patients.FirstOrDefault(b => b.Mrn == id).LastName;
        //    ViewBag.Dob = repository.Patients.FirstOrDefault(b => b.Mrn == id).Dob;

        //    if (repository.PatientAlerts.FirstOrDefault(b => b.Mrn == id) == null)
        //    {
        //        ViewBag.MRN = id;
        //    }
        //    else
        //    {
        //        ViewBag.MRN = repository.PatientAlerts.FirstOrDefault(b => b.Mrn == id).Mrn;
        //    }

        //    ViewBag.LastModified = @DateTime.Now;

        //    //var queryAlertType = repository.AlertTypes.OrderBy(a => a.Name).Select(r => new { r.AlertId, r.Name });
        //    //ViewBag.AlertTypes = new SelectList(queryAlertType.AsEnumerable(), "AlertId", "Name", 0);

        //    ViewBag.AlertType = repository.AlertTypes.OrderBy(a => a.Name).Select(a =>
        //            new SelectListItem
        //            {
        //                Value = a.AlertId.ToString(),
        //                Text = a.Name
        //            }).ToList();

        //    var queryRestriction = repository.Restrictions.OrderBy(r => r.Name).Include(r => r.PatientRestrictions).Select(r => new { r.RestrictionId, r.Name });
        //    ViewBag.Restriction = new SelectList(queryRestriction.AsEnumerable(), "RestrictionId", "Name", 0);

        //    //ViewBag.Restriction = repository.Restrictions.OrderBy(r => r.Name).Include(r => r.PatientRestrictions).Select(r =>
        //    //            new SelectListItem
        //    //            {
        //    //                Value = r.RestrictionId.ToString(),
        //    //                Text = r.Name
        //    //            }).ToList();

        //    //var query = repository.FallRisk.Select(r => new { r.FallRiskId, r.FallRisk.Name });
        //    //ViewBag.PatientFallRisk = new SelectList(query.AsEnumerable(), "FallRiskId", "Name", 0);
        //    ViewBag.PatientFallRisk = repository.FallRisks.OrderBy(r => r.Name).Include(r => r.PatientFallRisks).Select(r =>
        //           new SelectListItem
        //           {
        //               Value = r.FallRiskId.ToString(),
        //               Text = r.Name
        //           }).ToList();



        //    ViewBag.Allergens = repository.Allergens.OrderBy(r => r.AllergenName).Include(r => r.PatientAllergy)
        //    .Select(r =>
        //       new SelectListItem
        //       {
        //           Value = r.AllergenId.ToString(),
        //           Text = r.AllergenName
        //       }).ToList();



        //    ViewBag.Reactions = repository.Reactions.OrderBy(r => r.Name).Include(r => r.PatientAllergy).Select(r =>
        //          new SelectListItem
        //          {
        //              Value = r.ReactionId.ToString(),
        //              Text = r.Name
        //          }).ToList();

        //    return View();

        //}



        //[HttpPost]
        //[ActionName("AddAlert")]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddAlert(AlertsViewModel model)
        //{
        //    Console.WriteLine("Trying to save(PatientController)");
        //    //ViewBag.LastModified = DateTime.Today.AddYears(-1);
        //    if (ModelState.IsValid)
        //    {
        //        ViewBag.AlertType = repository.PatientAlerts.Include(p => p.AlertType);
        //        ViewBag.FallRiskID = repository.PatientAlerts.Include(p => p.PatientFallRisks);
        //        ViewBag.LastModified = @DateTime.Now;

        //        //var queryAlertType = repository.AlertTypes.OrderBy(a => a.Name).Select(r => new { r.AlertId, r.Name });
        //        //ViewBag.AlertTypes = new SelectList(queryAlertType.AsEnumerable(), "AlertId", "Name", 0);
        //        ViewBag.AlertType = repository.AlertTypes.Select(a =>
        //                new SelectListItem
        //                {
        //                    Value = a.AlertId.ToString(),
        //                    Text = a.Name
        //                }).ToList();

        //        var queryRestriction = repository.Restrictions.OrderBy(r => r.Name).Include(r => r.PatientRestrictions).Select(r => new { r.RestrictionId, r.Name });
        //        ViewBag.Restriction = new SelectList(queryRestriction.AsEnumerable(), "RestrictionId", "Name", 0);



        //        //var query = repository.FallRisk.Select(r => new { r.FallRiskId, r.Description });
        //        //ViewBag.PatientFallRisk = new SelectList(query.AsEnumerable(), "FallRiskId", "Description", 0);
        //        ViewBag.PatientFallRisk = repository.FallRisks.Include(r => r.PatientFallRisks).Select(r =>
        //           new SelectListItem
        //           {
        //               Value = r.FallRiskId.ToString(),
        //               Text = r.Name
        //           }).ToList();



        //        repository.AddAlert(model);
        //        string myUrl = "ListAlerts/" + model.Mrn;
        //        return Redirect(myUrl);

        //    }
        //    return View();
        //}

        // Load page for adding patient alerts
        public IActionResult DisplayAddAlert(string id)
        {
            ViewBag.myMrn = id;
            ViewBag.LastModified = DateTime.Today;
            //ViewBags for Patient Banner at top of page
            ViewBag.FirstName = repository.Patients.FirstOrDefault(b => b.Mrn == id).FirstName;
            ViewBag.MiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == id).MiddleName;
            ViewBag.LastName = repository.Patients.FirstOrDefault(b => b.Mrn == id).LastName;
            ViewBag.Dob = repository.Patients.FirstOrDefault(b => b.Mrn == id).Dob;

            if (repository.PatientAlerts.FirstOrDefault(b => b.Mrn == id) == null)
            {
                ViewBag.MRN = id;
            }
            else
            {
                ViewBag.MRN = repository.PatientAlerts.FirstOrDefault(b => b.Mrn == id).Mrn;
            }

            ViewBag.LastModified = @DateTime.Now;

            ViewBag.AlertType = repository.AlertTypes.OrderBy(a => a.Name).Select(a =>
                    new SelectListItem
                    {
                        Value = a.AlertId.ToString(),
                        Text = a.Name
                    }).ToList();

            ViewBag.Restriction = repository.Restrictions.OrderBy(r => r.Name).Include(r => r.PatientRestrictions).Select(r =>
                        new SelectListItem
                        {
                            Value = r.RestrictionId.ToString(),
                            Text = r.Name
                        }).ToList();

            //var query = repository.FallRisk.Select(r => new { r.FallRiskId, r.FallRisk.Name });
            //ViewBag.PatientFallRisk = new SelectList(query.AsEnumerable(), "FallRiskId", "Name", 0);
            ViewBag.PatientFallRisk = repository.FallRisks.OrderBy(r => r.Name).Include(r => r.PatientFallRisks).Select(r =>
                   new SelectListItem
                   {
                       Value = r.FallRiskId.ToString(),
                       Text = r.Name
                   }).ToList();



            ViewBag.Allergens = repository.Allergens.OrderBy(r => r.AllergenName).Include(r => r.PatientAllergy)
            .Select(r =>
               new SelectListItem
               {
                   Value = r.AllergenId.ToString(),
                   Text = r.AllergenName
               }).ToList();



            ViewBag.Reactions = repository.Reactions.OrderBy(r => r.Name).Include(r => r.PatientAllergy).Select(r =>
                  new SelectListItem
                  {
                      Value = r.ReactionId.ToString(),
                      Text = r.Name
                  }).ToList();

            return View();

        }



        [HttpPost]
        [ActionName("AddAlert")]
        [ValidateAntiForgeryToken]
        public IActionResult AddAlert(AlertsViewModel model)
        {
            Console.WriteLine("Trying to save(PatientController)");
            //ViewBag.LastModified = DateTime.Today.AddYears(-1);
            if (ModelState.IsValid)
            {
                ViewBag.AlertType = repository.PatientAlerts.Include(p => p.AlertType);
                ViewBag.FallRiskID = repository.PatientAlerts.Include(p => p.PatientFallRisks);
                ViewBag.LastModified = @DateTime.Now;


                ViewBag.AlertType = repository.AlertTypes.Select(a =>
                        new SelectListItem
                        {
                            Value = a.AlertId.ToString(),
                            Text = a.Name
                        }).ToList();


                ViewBag.Restriction = repository.Restrictions.Include(r => r.PatientRestrictions).Select(r =>
                        new SelectListItem
                        {
                            Value = r.RestrictionId.ToString(),
                            Text = r.Name
                        }).ToList();

                //var query = repository.FallRisk.Select(r => new { r.FallRiskId, r.Description });
                //ViewBag.PatientFallRisk = new SelectList(query.AsEnumerable(), "FallRiskId", "Description", 0);
                ViewBag.PatientFallRisk = repository.FallRisks.Include(r => r.PatientFallRisks).Select(r =>
                   new SelectListItem
                   {
                       Value = r.FallRiskId.ToString(),
                       Text = r.Name
                   }).ToList();



                repository.AddAlert(model);
                string myUrl = "ListAlerts/" + model.Mrn;
                return Redirect(myUrl);

            }
            return View();
        }

        // Displays the Edit Patient page
        public IActionResult EditPatientAlert(int id, string mrn)
        {
            ViewBag.myMrn = mrn;
            //ViewBags for Patient Banner at top of page
            ViewBag.FirstName = repository.Patients.FirstOrDefault(b => b.Mrn == mrn).FirstName;
            ViewBag.MiddleName = repository.Patients.FirstOrDefault(b => b.Mrn == mrn).MiddleName;
            ViewBag.LastName = repository.Patients.FirstOrDefault(b => b.Mrn == mrn).LastName;
            ViewBag.Dob = repository.Patients.FirstOrDefault(b => b.Mrn == mrn).Dob;

            //ViewBag.LastModified = DateTime.Today.AddYears(-1);
            ViewBag.AlertTypeId = repository.PatientAlerts.FirstOrDefault(p => p.PatientAlertId == id).AlertTypeId;


            var myAlertType = (from pa in repository.PatientAlerts
                               join at in repository.AlertTypes on pa.AlertTypeId equals at.AlertId
                               where pa.PatientAlertId == id
                               select new
                               {
                                   alertType = at.Name

                               }).FirstOrDefault();

            ViewBag.MyAlertType = myAlertType.alertType;

            ViewBag.Comments = repository.PatientAlerts.FirstOrDefault(p => p.PatientAlertId == id).Comments;
            ViewBag.StartDate = repository.PatientAlerts.FirstOrDefault(p => p.PatientAlertId == id).StartDate.ToString("MM/dd/yyyy");

            ViewBag.EndDate = repository.PatientAlerts.FirstOrDefault(p => p.PatientAlertId == id).EndDate;
            //ViewBag.EndDate = checkEndDate != null ? checkEndDate : "N/A";

            var checkActive = repository.PatientAlerts.FirstOrDefault(p => p.PatientAlertId == id).IsActive;
            ViewBag.Active = checkActive == true ? "Yes" : "No";

            var myFallRisk = (from pa in repository.PatientAlerts
                              join pf in repository.PatientFallRisks on pa.PatientAlertId equals pf.PatientAlertId
                              join fr in repository.FallRisks on pf.FallRiskId equals fr.FallRiskId
                              where pf.PatientAlertId == id
                              select new
                              {
                                  fallrisk = fr.Name

                              }).FirstOrDefault();

            if (myFallRisk == null)
            {
                ViewBag.FallRisk = "";
            }
            else
            {
                ViewBag.FallRisk = myFallRisk.fallrisk;
            }


            var myRestriction = (from pa in repository.PatientAlerts
                                 join pr in repository.PatientRestrictions on pa.PatientAlertId equals pr.PatientAlertId
                                 join re in repository.Restrictions on pr.RestrictionTypeId equals re.RestrictionId
                                 where pr.PatientAlertId == id
                                 select new
                                 {
                                     theRestriction = re.Name

                                 }).FirstOrDefault();

            if (myRestriction == null)
            {
                ViewBag.RestrictionValue = "";
            }
            else
            {
                ViewBag.RestrictionValue = myRestriction.theRestriction;
            }

            var myAllergen = (from pa in repository.PatientAlerts
                              join pal in repository.PatientAllergy on pa.PatientAlertId equals pal.PatientAlertId
                              join al in repository.Allergens on pal.AllergenId equals al.AllergenId
                              where pal.PatientAlertId == id
                              select new
                              {
                                  allergen = al.AllergenName

                              }).FirstOrDefault();

            if (myAllergen == null)
            {
                ViewBag.AllergenValue = "";
            }
            else
            {
                ViewBag.AllergenValue = myAllergen.allergen;
            }

            var myReaction = (from pa in repository.PatientAlerts
                              join pal in repository.PatientAllergy on pa.PatientAlertId equals pal.PatientAlertId
                              join rea in repository.Reactions on pal.ReactionId equals rea.ReactionId
                              where pal.PatientAlertId == id
                              select new
                              {
                                  reaction = rea.Name

                              }).FirstOrDefault();

            if (myReaction == null)
            {
                ViewBag.ReactionValue = "";
            }
            else
            {
                ViewBag.ReactionValue = myReaction.reaction;
            }

            ViewBag.AlertType = repository.AlertTypes.OrderBy(a => a.Name).Select(a =>
                    new SelectListItem
                    {
                        Value = a.AlertId.ToString(),
                        Text = a.Name
                    }).ToList();

            //ViewBag.PatientFallRisk = repository.FallRisks.Include(r => r.PatientFallRisks).Select(r =>
            //       new SelectListItem
            //       {
            //           Value = r.FallRiskId.ToString(),
            //           Text = r.Name
            //       }).ToList();

            //ViewBag.Restriction = repository.Restrictions.Include(r => r.PatientRestrictions).Select(r =>
            //            new SelectListItem
            //            {
            //                Value = r.RestrictionId.ToString(),
            //                Text = r.Name
            //            }).ToList();

            //ViewBag.Allergens = repository.Allergens.OrderBy(r => r.AllergenName).Include(r => r.PatientAllergy)
            //.Select(r =>
            //   new SelectListItem
            //   {
            //       Value = r.AllergenId.ToString(),
            //       Text = r.AllergenName
            //   }).ToList();



            return View(repository.PatientAlerts.FirstOrDefault(p => p.PatientAlertId == id));

        }


        [HttpPost]
        [ActionName("UpdateAlert")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAlert(PatientAlerts model, int id)
        {
            Console.WriteLine("Trying to save(PatientController)");
            //ViewBag.LastModified = DateTime.Today.AddYears(-1);
            if (ModelState.IsValid)
            {
                model.LastModified = @DateTime.Now;
                ViewBag.AlertType = repository.PatientAlerts.Include(p => p.AlertType);
                ViewBag.FallRiskID = repository.PatientAlerts.Include(p => p.PatientFallRisks);
                ViewBag.LastModified = @DateTime.Now;

                repository.EditAlert(model);
                string myUrl = "ListAlerts/" + model.Mrn;
                return Redirect(myUrl);

            }
            return View();
        }


        public IActionResult DisplayFacilities()
        {
            ViewBag.Facilities = repository.Facilities.Select(f =>
                                 new SelectListItem
                                 {
                                     Value = f.FacilityId.ToString(),
                                     Text = f.Name
                                 }).ToList();
            return View();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using isprojectHiT.Models;
using PagedList;
using PagedList.Mvc;

namespace IS_Proj_HIT.Controllers
{
    public class HomeController : Controller
    {
        private IWCTCHealthSystemRepository repository;
        public HomeController(IWCTCHealthSystemRepository repo) => repository = repo;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ethnicity() => View(repository.Ethnicities);

        public IActionResult Gender() => View(repository.Genders);



        public IActionResult Discharge() => View(repository.Discharges);
        
        public IActionResult SignUp() => View();

        public IActionResult Login() => View();

        public IActionResult PatientLookup() => View();

        /*
                public IActionResult Privacy()
                {
                    return View();
                }

                [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                public IActionResult Error()
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
                */
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CovidVaccinationCenterApp.Models;

// Do not change the namespace
namespace CovidVaccinationCenterApp.Controllers
{
    // Do not change the class name
    public class VaccinationCenterController : Controller
    {
        VaccinationCentersRepository repository;
        static List<string> VaccineCategories = new List<string>
        { "Covaxin", "Covishield", "Spuntik V"};
        public VaccinationCenterController()
        {
            // Initialize fields here
        }

        public ActionResult Index()
        {
            // Implement code here 
            return View();
        }

        public ActionResult Add()
        {
	    // Implement code here 
            return View();
        }

	 // Do not change the method signature
        // Add attributes here
        [HttpPost]
        public ActionResult Add(VaccinationCenters model)
        {
           // Implement code here 

            return View();
        }

        public ActionResult Search()
        {
            // Implement code here 
            return View();
        }

	// Do not change the method signature
        // Add attributes here
        [HttpPost]
        public ActionResult Search(SearchVaccinationCentersViewModel model)
        {
           // Implement code here 
            return View();
        }
    }
}
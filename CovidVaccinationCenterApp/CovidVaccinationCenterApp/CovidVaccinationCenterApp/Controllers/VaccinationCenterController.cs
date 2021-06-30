using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CovidVaccinationCenterApp.Models;

namespace CovidVaccinationCenterApp.Controllers
{
    public class VaccinationCenterController : Controller
    {
        VaccinationCentersRepository repository;
        static List<string> VaccineCategories = new List<string>
        { "Covaxin", "Covishield", "Spuntik V"};
        public VaccinationCenterController()
        {
            repository = new VaccinationCentersRepository();
        }

        public ActionResult Index()
        {
            var list = repository.ListVaccinationCenters();
            return View(list);
        }

        public ActionResult Add()
        {
            ViewBag.VaccineCategories = new SelectList(VaccineCategories);
            return View();
        }

        [HttpPost]
        public ActionResult Add(VaccinationCenters model)
        {
            ViewBag.VaccineCategories = new SelectList(VaccineCategories);

            if (!ModelState.IsValid)
                return View(model);

            var Added = repository.AddVaccinationCenter(model);
            if (Added)
                ViewBag.Message = "Vaccination center details added successfully";
            else
                ViewBag.Message = "Failed to add vaccination center details. Try again later";

            return View(model);
        }

        public ActionResult Search()
        {
            ViewBag.VaccineCategories = new SelectList(VaccineCategories);
            return View(new SearchVaccinationCentersViewModel());
        }

        [HttpPost]
        public ActionResult Search(SearchVaccinationCentersViewModel model)
        {
            ViewBag.VaccineCategories = new SelectList(VaccineCategories);

            if (!ModelState.IsValid)
                return View(model);

            model.Centers = repository.Search(model.City, model.VaccineCategory);
            return View(model);
        }
    }
}
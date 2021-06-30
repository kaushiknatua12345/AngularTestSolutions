using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CovidVaccinationCenterApp.Models
{
    public class SearchVaccinationCentersViewModel
    {
        [Required(ErrorMessage = "Please provide city name to search")]
        [StringLength(25, ErrorMessage = "City name must not exceed 25 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide Vaccine Category to search")]
        public string VaccineCategory { get; set; }

        public List<VaccinationCenters> Centers { get; set; }
    }
}
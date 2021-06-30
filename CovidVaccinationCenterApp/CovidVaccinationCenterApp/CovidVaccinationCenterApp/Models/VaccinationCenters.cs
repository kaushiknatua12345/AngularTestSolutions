using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CovidVaccinationCenterApp.Models
{
    public class VaccinationCenters
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide vaccination center name")]
        [StringLength(25, ErrorMessage = "Vaccination center name cannot exceed 25 characters")]
        [Display(Name = "Vaccination Center Name")]
        public string VaccinationCenterName { get; set; }

        [Required(ErrorMessage = "Please provide vaccine category")]
        [StringLength(30)]
        [Display(Name = "Vaccine Category")]
        public string VaccineCategory { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please provide mobile number")]
        [RegularExpression("^[\\d]{10}$", ErrorMessage = "Please enter 10 digit mobile number")]
        [StringLength(10)]
        [Display(Name = "Contact Mobile No.")]
        public string ContactMobileNo { get; set; }

        [Required(ErrorMessage = "Please provide city name")]
        [StringLength(25, ErrorMessage = "City name must not exceed 25 characters")]
        [Display(Name = "City")]
        public string City { get; set; }

    }
}
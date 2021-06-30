using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Do not change the namespace
namespace CovidVaccinationCenterApp.Models
{
    // Do not change the class name
    public class VaccinationCentersRepository
    {
        public VaccinationCentersContext context;

        public VaccinationCentersRepository()
        {
            // Initialize fields here
        }
	
	// Do not change the method signature
        public bool AddVaccinationCenter(VaccinationCenters model)
        {
            bool IsAdded = false;

             // Implement code here

            return IsAdded;
        }

	// Do not change the method signature
        public List<VaccinationCenters> Search(string city, string category)
        {
            // Implement code here

	}

	// Do not change the method signature
        public List<VaccinationCenters> ListVaccinationCenters()
        {
             // Implement code here
        }
    }
}
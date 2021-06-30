using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidVaccinationCenterApp.Models
{
    public class VaccinationCentersRepository
    {
        public VaccinationCentersContext context;

        public VaccinationCentersRepository()
        {
            context = new VaccinationCentersContext();
        }

        public bool AddVaccinationCenter(VaccinationCenters model)
        {
            bool IsAdded = false;

            var isPresent = context.Centers.SingleOrDefault(d => d.ContactMobileNo == model.ContactMobileNo
                                                        && d.City == model.City
                                                        && d.VaccinationCenterName == model.VaccinationCenterName);
            if (isPresent != null)
                return IsAdded;

            if (model.StartDate >= DateTime.Today)
            {
                context.Centers.Add(model);
                IsAdded = context.SaveChanges() > 0;
            }
            else
            {
                IsAdded = false;
            }

            return IsAdded;
        }

        public List<VaccinationCenters> Search(string city, string category)
        {
            var VaccinationCenterList = from vaccinationcenter in context.Centers
                               where vaccinationcenter.City.ToLower().Contains(city.ToLower())
                               && vaccinationcenter.VaccineCategory.Equals(category)
                               select vaccinationcenter;
            return VaccinationCenterList.ToList();
        }

        public List<VaccinationCenters> ListVaccinationCenters()
        {
            var VaccinationCenterList = from stadium in context.Centers
                               select stadium;
            return VaccinationCenterList.ToList();
        }
    }
}
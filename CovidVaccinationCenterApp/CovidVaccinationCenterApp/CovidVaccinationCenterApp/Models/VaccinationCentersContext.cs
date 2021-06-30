using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CovidVaccinationCenterApp.Models
{
    public class VaccinationCentersContext:DbContext
    {
        public VaccinationCentersContext():base("name=SqlCon")
        {

        }
        public DbSet<VaccinationCenters> Centers { get; set; }
    }
}
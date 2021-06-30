using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CovidVaccinationCenterApp.Models;
using CovidVaccinationCenterApp.Tests.TestExtensions;

namespace CovidVaccinationCenterApp.Tests.Tests.FunctionalTests
{
    [Order(6), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Models", "VaccinationCentersRepository")]
    public class VaccinationCentersRepository_FunctionalTests:TestBase
    {
        public VaccinationCentersRepository_FunctionalTests(string assemblyName, string namespaceName, string typeName) : base(assemblyName, namespaceName, typeName)
        {
        }

        [Test, Order(1)]
        public void AddVaccinationCenter_Test()
        {
            string MethodName = "AddVaccinationCenter";
            try
            {
                var Obj = new VaccinationCenters
                {
                    VaccinationCenterName= "AIMS",
                    VaccineCategory = "Covaxin",
                    StartDate = DateTime.Today,
                    City = "Kochi",
                    ContactMobileNo = DateTime.UtcNow.Ticks.ToString().Substring(8)
                };
                bool Result = InvokeMethod<bool>(MethodName, type, Obj);
                Assert.IsTrue(Result, $"{MethodName} method of class {typeName} doesnot returns true on saving the data");

            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: MethodName));
            }
        }

        [Test, Order(2)]
        public void AddVaccinationCenter_InvalidStartDate_Test()
        {
            string MethodName = "AddVaccinationCenter";
            try
            {
                var Obj = new VaccinationCenters
                {
                    VaccinationCenterName = "NRS Hospital",
                    VaccineCategory = "Covaxin",
                    StartDate = Convert.ToDateTime("2021,01,14"),
                    City = "Kochi",
                    ContactMobileNo = DateTime.UtcNow.Ticks.ToString().Substring(8)
                };
                bool Result = InvokeMethod<bool>(MethodName, type, Obj);
                Assert.IsFalse(Result, $"{MethodName} method of class {typeName} doesnot returns true on saving the data");

            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: MethodName));
            }
        }

        [Test, Order(3)]
        public void Add_DuplicateVaccinationCenter_Test()
        {
            string MethodName = "AddVaccinationCenter";
            try
            {
                var Context = new VaccinationCentersContext();

                var Obj = Context.Centers.First();
                bool Result = InvokeMethod<bool>(MethodName, type, Obj);
                Assert.False(Result, $"{MethodName} method of class {typeName} doesnot returns false on trying to add a duplicate vaccination center");

            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: MethodName));
            }
        }

        [Test, Order(4)]
        public void Search_Test()
        {
            string MethodName = "Search";
            try
            {

                var Result = InvokeMethod<List<VaccinationCenters>>(MethodName, type, new object[] { "Kolkata", "Covishield" });
                Assert.IsNotNull(Result, $"{MethodName} method of class {typeName} doesnot returns list of Vaccination Centers saved in the database");

            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: MethodName));
            }
        }

        [Test, Order(5)]
        public void AddVaccinationCenter_Search_Test()
        {
            string MethodName = "AddVaccinationCenter";
            string MethodName1 = "Search";
            try
            {

                var CountBeforeAdd = InvokeMethod<List<VaccinationCenters>>(MethodName1, type, "Kolkata", "Covishield").Count;

                var Obj = new VaccinationCenters
                {
                    VaccinationCenterName = "APC Hospital",
                    VaccineCategory = "Covishield",
                    StartDate = DateTime.Today,
                    City = "Kolkata",
                    ContactMobileNo = DateTime.UtcNow.Ticks.ToString().Substring(8)
                };
                var AddResult = InvokeMethod<bool>(MethodName, type, Obj);

                var CountAfterAdd = InvokeMethod<List<VaccinationCenters>>(MethodName1, type, "Kolkata", "Covishield").Count;

                Assert.AreEqual(CountBeforeAdd + 1, CountAfterAdd, $"{MethodName} method of class {typeName} doesnot returns newly added records.");

            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: MethodName + " and " + MethodName1));
            }
        }

    }
}

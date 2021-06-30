using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidVaccinationCenterApp.Models;
using CovidVaccinationCenterApp.Tests.TestExtensions;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CovidVaccinationCenterApp.Tests.Tests.FunctionalTests
{
    [Order(7), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Controllers", "VaccinationCenterController")]
    public class VaccinationCenterController_FunctionalTests : TestBase
    {
        public VaccinationCenterController_FunctionalTests(string assemblyName, string namespaceName, string typeName) : base(assemblyName, namespaceName, typeName)
        {
        }

        [Test, Order(1)]
        [TestCase("Add")]
        [TestCase("Search")]
        [TestCase("Index")]
        public void GetRequestTest(string methodName)
        {
            try
            {
                var method = base.type.GetMethod(methodName, new Type[] { });

                var result = (ViewResult)method.Invoke(GetTypeInstance(), new Type[] { });
                Assert.IsNotNull(result, $"{methodName} httpget action method of class {typeName} does not return a view.");

                Assert.IsNotNull(result.ViewBag.VaccineCategories, $"{methodName} http get action of {typeName} controller does not store VaccineCategories in the ViewBag.VaccineCategories property");

                Assert.IsInstanceOf<SelectList>(result.ViewBag.VaccineCategories, $"{methodName} http get action of {typeName} controller doesnot stores a SelectList in ViewBag's VaccineCategories property");
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: methodName));
            }
        }

        [Test, Order(2)]
        public void Add_ValidVaccinationCenter_PostRequestTest()
        {
            string methodName = "Add";
            try
            {
                var method = base.type.GetMethod(methodName, new Type[] { typeof(VaccinationCenters) });
                var Obj = new VaccinationCenters
                {
                    VaccinationCenterName = "ARC Hospital",
                    VaccineCategory = "Covaxin",
                    StartDate = DateTime.Today,
                    City = "Pune",
                    ContactMobileNo = DateTime.UtcNow.Ticks.ToString().Substring(8)
                };
                var result = method.Invoke(GetTypeInstance(), new object[] { Obj }) as ViewResult;
                Assert.IsNotNull(result, $"{methodName} httppost action method of class {typeName} doesnot returns a view on saving a valid vaccination center object.");
                Assert.IsNotNull(result.ViewBag.Message, $"{methodName} httppost action method of class {typeName} doesnot stores a message in viewbag");
                Assert.AreEqual("Vaccination center details added successfully", result.ViewBag.Message, $"{methodName} httppost action method of class {typeName} doesnot stores the message 'Vaccination center details added successfully' in viewbag");
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: methodName));
            }
        }

        [Test, Order(3)]
        public void Add_DuplicateVaccinationCenter_PostRequestTest()
        {
            string methodName = "Add";
            try
            {
                var method = base.type.GetMethod(methodName, new Type[] { typeof(VaccinationCenters) });
                var context = new VaccinationCentersContext();
                var Obj = context.Centers.First();
                var result = method.Invoke(GetTypeInstance(), new object[] { Obj }) as ViewResult;
                Assert.IsNotNull(result, $"{methodName} httppost action method of class {typeName} doesnot returns a view on trying to save a duplicate vaccination center object");
                Assert.IsNotNull(result.ViewBag.Message, $"{methodName} httppost action method of class {typeName} doesnot stores a message in viewbag");
                Assert.AreEqual("Failed to add vaccination center details. Try again later", result.ViewBag.Message, $"{methodName} httppost action method of class {typeName} doesnot stores the message 'Failed to add vaccination center details. Try again later' in viewbag");
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: methodName));
            }
        }

        [Test, Order(4)]
        public void Add_InvalidStartDate_PostRequestTest()
        {
            string methodName = "Add";
            try
            {
                var method = base.type.GetMethod(methodName, new Type[] { typeof(VaccinationCenters) });
                var context = new VaccinationCenters();
                var Obj = new VaccinationCenters
                {
                    VaccinationCenterName = "ARC Hospital",
                    VaccineCategory = "Covaxin",
                    StartDate = Convert.ToDateTime("2021,01,20"),
                    City = "Pune",
                    ContactMobileNo = DateTime.UtcNow.Ticks.ToString().Substring(8)
                };
                var result = method.Invoke(GetTypeInstance(), new object[] { Obj }) as ViewResult;
                Assert.IsNotNull(result, $"{methodName} httppost action method of class {typeName} doesnot returns a view on trying to save a invalid start date under vaccination center object");
                Assert.IsNotNull(result.ViewBag.Message, $"{methodName} httppost action method of class {typeName} doesnot stores a message in viewbag");
                Assert.AreEqual("Failed to add vaccination center details. Try again later", result.ViewBag.Message, $"{methodName} httppost action method of class {typeName} doesnot stores the message 'Failed to add vaccination center details. Try again later' in viewbag");
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: methodName));
            }
        }

        [Test, Order(5)]
        public void Add_InvalidVaccinationCenter_PostRequestTest()
        {
            try
            {
                var Obj = new VaccinationCenters
                {
                    VaccinationCenterName = null,
                    VaccineCategory = null,
                    StartDate = DateTime.Now,
                    City = null,
                    ContactMobileNo = null
                };

                var RequiredValidations = new Dictionary<string, string>
                {
                    { "VaccinationCenterName", "Please provide vaccination center name" },
                    { "VaccineCategory", "Please provide vaccine category" },
                    { "ContactMobileNo", "Please provide mobile number" },
                    { "City", "Please provide city name" }
                };

                var Results = ValidateModel(Obj);

                TestValidations("Required", RequiredValidations, Results);

                var StringLengthValidations = new Dictionary<string, string>
                {
                    { "VaccinationCenterName", "Vaccination center name cannot exceed 25 characters" },
                    { "City", "City name must not exceed 25 characters" }
                };

                Obj.VaccinationCenterName = "abcdefghijklmnopqrstuvwxyz";
                Obj.City = "abcdefghijklmnopqrstuvwxyz";

                Results = ValidateModel(Obj);
                TestValidations("StringLength", StringLengthValidations, Results);

                Obj.VaccinationCenterName = "ARCP Hospital";
                Obj.City = "Pune";
                Obj.VaccineCategory = "Covaxin";
                Obj.Id = 0;
                Obj.StartDate = DateTime.Today;
                Obj.ContactMobileNo = "123456789";
                var RegularExpressionValidations = new Dictionary<string, string>
                {
                    { "ContactMobileNo", "Please enter 10 digit mobile number" }
                };

                Results = ValidateModel(Obj);
                TestValidations("RegularExpression", RegularExpressionValidations, Results);
            }

            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here, verify the program logic");
            }

            void TestValidations(string validationName,
                                 Dictionary<string, string> RequiredValidations,
                                 IList<ValidationResult> Results)
            {
                bool IsInvalid = false;
                foreach (var item in RequiredValidations)
                {
                    IsInvalid = Results.Any(m => m.MemberNames.Contains(item.Key) && m.ErrorMessage.Contains(item.Value));
                    Assert.IsTrue(IsInvalid, $"VaccinationCenters entity doesnot display the validation message {item.Value} for {validationName} validation failure for {item.Key} property");
                }


            }
        }

        [Test, Order(6)]
        public void Search_Validation_PostRequestTest()
        {
            try
            {
                var Obj = new SearchVaccinationCentersViewModel
                {
                    VaccineCategory = null,
                    City = null
                };

                var RequiredValidations = new Dictionary<string, string>
                {
                    { "VaccineCategory", "Please provide Vaccine Category to search" },
                    { "City", "Please provide city name to search" }
                };

                var Results = ValidateModel(Obj);

                TestValidations("Required", RequiredValidations, Results);

                var StringLengthValidations = new Dictionary<string, string>
                {
                    { "City", "City name must not exceed 25 characters" }
                };


                Obj.City = "abcdefghijklmnopqrstuvwxyz";

                Results = ValidateModel(Obj);
                TestValidations("StringLength", StringLengthValidations, Results);


            }

            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here, verify the program logic");
            }

            void TestValidations(string validationName,
                                 Dictionary<string, string> RequiredValidations,
                                 IList<ValidationResult> Results)
            {
                bool IsInvalid = false;
                foreach (var item in RequiredValidations)
                {
                    IsInvalid = Results.Any(m => m.MemberNames.Contains(item.Key) && m.ErrorMessage.Contains(item.Value));
                    Assert.IsTrue(IsInvalid, $"SearchVaccinationCentersViewModel doesnot display the validation message {item.Value} for {validationName} validation failure for {item.Key} property");
                }


            }
        }

        [Test, Order(7)]
        public void Search_ValidCriteria_Test()
        {
            string methodName = "Search";
            try
            {
                var method = base.type.GetMethod(methodName, new Type[] { typeof(SearchVaccinationCentersViewModel) });
                var Obj = new SearchVaccinationCentersViewModel
                {
                    City = "Kolkata",
                    VaccineCategory = "Covishield"

                };
                var result = method.Invoke(GetTypeInstance(), new object[] { Obj }) as ViewResult;
                var model = result.Model as SearchVaccinationCentersViewModel;
                Assert.IsNotNull(model.Centers, $"{methodName} httppost action of {typeName} doesnot assigns Centers property of SearchVaccinationCentersViewModel for valid search criteria");


            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: methodName));
            }
        }

        [Test, Order(8)]
        public void Search_InValidCriteria_Test()
        {
            string methodName = "Search";
            try
            {
                var method = base.type.GetMethod(methodName, new Type[] { typeof(SearchVaccinationCentersViewModel) });
                var Obj = new SearchVaccinationCentersViewModel
                {
                    City = "Xyz",
                    VaccineCategory = "abcde"

                };
                var result = method.Invoke(GetTypeInstance(), new object[] { Obj }) as ViewResult;
                var model = result.Model as SearchVaccinationCentersViewModel;
                Assert.AreEqual(0, model.Centers.Count, $"{methodName} httppost action of {typeName} assigns Centers property of SearchVaccinationCentersViewModel for invalid search criteria");


            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, methodName: methodName));
            }
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, validationResults, true);

            return validationResults;
        }
    }
}

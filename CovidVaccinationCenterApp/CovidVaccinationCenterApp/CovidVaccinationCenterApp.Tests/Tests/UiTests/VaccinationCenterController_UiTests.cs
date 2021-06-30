using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using CovidVaccinationCenterApp.Models;
using CovidVaccinationCenterApp.Tests.TestExtensions;
using System.Transactions;

namespace CovidVaccinationCenterApp.Tests.Tests.UiTests
{
    public class RollbackAttribute : Attribute, ITestAction
    {
        private TransactionScope transaction;

        public void BeforeTest(ITest test)
        {
            transaction = new TransactionScope();
        }
        public void AfterTest(ITest test)
        {
            transaction.Dispose();
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
    [Order(8), TestFixture("http://localhost:4300/")]
    public class VaccinationCenterController_UiTests
    {
        private readonly string appURL;
        private IWebDriver driver;

        public VaccinationCenterController_UiTests(string applicationURL)
        {
            this.appURL = applicationURL;

        }

        [OneTimeSetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(appURL);
        }

        [OneTimeTearDown]
        public void Destroy()
        {
            driver.Close();
            driver.Dispose();
        }


        [Test, Order(1)]
        public void StartPage_Test()
        {
            try
            {
                driver.Navigate().GoToUrl(appURL);
                string title = driver.Title;
                StringAssert.Contains("Add", title, $"Application doesnot start with the page titled Add");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while testing application start page title. \nException :\n{ex.InnerException?.Message}\nStack trace : \n{ex.InnerException?.StackTrace}");
            }
        }

        [Test, Order(2)]
        public void AddVaccinationCenter_SearchVAccinationCenter_NavigationLinksTest()
        {
            try
            {
                driver.ClickElement("lnkSearch");
                string SearchPageTitle = driver.Title;

                driver.ClickElement("lnkAdd");

                string AddPageTitle = driver.Title;


                StringAssert.Contains("Add", AddPageTitle, $"Application does not navigates to Add page on clicking Add Vaccination Center hyperlink");

                StringAssert.Contains("Search", SearchPageTitle, $"Application doesnot navigates to Search page on clicking Search Vaccination Centers hyperlink");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while testing Add Vaccination Center and Search Vaccination Centers navigation links. \nException :\n{ex.InnerException?.Message}\nStack trace : \n{ex.InnerException?.StackTrace}");
            }
        }


        [Test, Order(3)]
        [Rollback]
        public void AddVaccinationCenter_Test()
        {
            try
            {
                var ExpectedSuccessMessage = "Vaccination center details added successfully";
                var ExpectedFailureMessage = "Failed to add vaccination center details. Try again later";
                driver.ClickElement("lnkAdd");

                var Element = driver.FindElement(By.Id("VaccineCategory"));
                Assert.IsNotNull(Element, $"Add Vaccination Center page doesn't displays the dropdown list for Vaccine Categories");
                var DropDown = new SelectElement(Element);

                var VaccineCategories = new List<string>
                { "Covaxin", "Covishield", "Spuntik V"};
                foreach (var group in VaccineCategories)
                {
                    var Found = DropDown.Options.Any(option => option.Text == group);
                    Assert.IsTrue(Found, $"VaccineCategory dropdown doesn't contains the value {group}");
                }
                string MobileNo = DateTime.UtcNow.Ticks.ToString().Substring(8);
                driver.SetElementText("VaccinationCenterName", "NRT Hospital");
                driver.SetElementText("StartDate", DateTime.Now.Date.ToShortDateString());
                driver.SetElementText("ContactMobileNo", MobileNo);
                driver.SetElementText("City", "Delhi");
                driver.SelectDropDownItemByText("VaccineCategory", "Covishield");

                driver.ClickElement("btnSubmit");

                var ActualMessage = driver.GetElementInnerText("h2", "@Id='Message'");
                Assert.AreEqual(ExpectedSuccessMessage, ActualMessage, $"Add vaccination center page doesnot displays the message - '{ExpectedSuccessMessage}' in h2 tag after saving a valid vaccination center object");

                driver.ClickElement("btnSubmit");

                ActualMessage = driver.GetElementInnerText("h2", "@Id='Message'");
                Assert.AreEqual(ExpectedFailureMessage, ActualMessage, $"Add vaccination center page doesnot displays the message - '{ExpectedSuccessMessage}' in h2 tag on trying to save a duplicate vaccination center object");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception trying to save vaccination center details from Add Vaccination Center page. \nException :\n{ex.InnerException?.Message}\nStack trace : \n{ex.InnerException?.StackTrace}");
            }
        }

        [Test, Order(4)]
        public void SearchVaccinationCenter_Test()
        {
            try
            {
                var WelcomeMessage = "Provide the search criteria to start looking for a vaccination center";
                var notFound = "No vaccination center found with the given search criteria";
                driver.ClickElement("lnkSearch");


                var ActualMessage = driver.GetElementInnerText("h2", "@Id='Message'");
                Assert.AreEqual(WelcomeMessage, ActualMessage, $"Search vaccination centers page doesnot displays the message - '{WelcomeMessage}' in h2 tag on opening the page");

                var Element = driver.FindElement(By.Id("VaccineCategory"));
                Assert.IsNotNull(Element, $"Search Vaccination Centers page doesn't displays the dropdown list for Vaccine Categories");
                var DropDown = new SelectElement(Element);

                var VaccineCategories = new List<string>
                { "Covaxin", "Covishield", "Spuntik V"};
                foreach (var group in VaccineCategories)
                {
                    var Found = DropDown.Options.Any(option => option.Text == group);
                    Assert.IsTrue(Found, $"VaccineCategory dropdown doesn't contains the value {group}");
                }


                driver.SetElementText("City", "Test City");
                driver.SelectDropDownItemByText("VaccineCategory", "Modernizer");
                driver.ClickElement("btnSubmit");

                ActualMessage = driver.GetElementInnerText("h2", "@Id='Message'");
                Assert.AreEqual(notFound, ActualMessage, $"Search vaccination center page doesnot displays the message - '{notFound}' in h2 tag when there are no vaccination centers for given search criteria");

                driver.SetElementText("City", "Kolkata");
                driver.SelectDropDownItemByText("VaccineCategory", "Covishield");
                driver.ClickElement("btnSubmit");

                var context = new VaccinationCentersContext();
                var counts = context.Centers.Count(d => d.City.ToLower() == "kolkata" && d.VaccineCategory == "Covishield");

                var TableRowCount = driver.GetTableRowsCount("tblVaccinationCenters") - 1;
                Assert.AreEqual(counts, TableRowCount, $"Search vaccination center page doesnot includes all the records in tblVaccinationCenters html table for given criteria. Rows count mis-match between database and html table.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception trying to search vaccination center details from Search page. \nException :\n{ex.InnerException?.Message}\nStack trace : \n{ex.InnerException?.StackTrace}");
            }
        }

        [Test, Order(5)]
        public void Index_Test()
        {
            try
            {
                driver.ClickElement("lnkIndex");

                var context = new VaccinationCentersContext();
                var counts = context.Centers.Count();

                var TableRowCount = driver.GetTableRowsCount("tblVaccinationCenters") - 1;
                Assert.AreEqual(counts, TableRowCount, $"Index page doesnot includes all the records in tblVaccinationCenters html table for given criteria. Rows count mis-match between database and html table.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception trying to display vaccination centers details from Index page. \nException :\n{ex.InnerException?.Message}\nStack trace : \n{ex.InnerException?.StackTrace}");
            }
        }
    }
}

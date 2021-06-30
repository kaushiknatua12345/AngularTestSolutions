using NUnit.Framework;
using CovidVaccinationCenterApp.Models;
using CovidVaccinationCenterApp.Tests.TestExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationCenterApp.Tests.Tests.StructuralTests
{     
     [Order(4), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Models", "VaccinationCentersRepository")]
    public class VaccineCentersRepository_StructuralTests : TestBase
    {
        public VaccineCentersRepository_StructuralTests(string assemblyName, string namespaceName, string typeName) 
            : base(assemblyName, namespaceName, typeName)
        {
        }

        [Test]
        public void Field_CreationTest()
        {
            try
            {
                var IsFound = HasField("context", "VaccinationCentersContext");
                Assert.IsTrue(IsFound,
                              Messages.GetFieldNotFoundMessage(fieldName: "context", fieldType: "VaccinationCentersContext"));
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, fieldName: "context"));
            }
        }

        [Test]
        public void AddVaccinationCenter_Method_CreationTest()
        {
            try
            {
                var Method = base.type.GetMethod("AddVaccinationCenter", new Type[] { typeof(VaccinationCenters) });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines AddVaccinationCenter() which accepts VaccinationCenters entity object as parameter");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check AddVaccinationCenter() method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

        [Test]
        public void Search_Method_CreationTest()
        {
            try
            {
                var Method = base.type.GetMethod("Search", new Type[] { typeof(string), typeof(string) });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines Search() method which accepts 2  string parameters");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check Search() method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

        [Test]
        public void ListVaccinationCenters_Method_CreationTest()
        {
            try
            {
                var Method = base.type.GetMethod("ListVaccinationCenters", new Type[] { });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines ListVaccinationCenters() method which accepts no parameters");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check ListVaccinationCenters() method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }
    }
}

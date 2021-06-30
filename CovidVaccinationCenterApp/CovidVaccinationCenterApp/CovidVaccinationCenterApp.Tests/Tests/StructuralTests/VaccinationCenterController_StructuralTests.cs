using NUnit.Framework;
using CovidVaccinationCenterApp.Models;
using CovidVaccinationCenterApp.Tests.TestExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CovidVaccinationCenterApp.Tests.Tests.StructuralTests
{
    [Order(5), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Controllers", "VaccinationCenterController")]
    public class VaccinationCenterController_StructuralTests : TestBase
    {
        public VaccinationCenterController_StructuralTests(string assemblyName, string namespaceName, string typeName) 
            : base(assemblyName, namespaceName, typeName)
        {
        }

        [Test]
        public void InheritsFrom_ControllerTest()
        {
            Assert.AreEqual("Controller", type.BaseType.Name, $"{base.type.Name} doesnot inherits from Controller base class");
        }

        [Test]
        public void Field_CreationTest()
        {
            try
            {
                var IsFound = HasField("repository", "VaccinationCentersRepository");
                Assert.IsTrue(IsFound,
                              Messages.GetFieldNotFoundMessage(fieldName: "repository", fieldType: "VaccinationCentersRepository"));
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, fieldName: "repository"));
            }
        }

        
        [Test]
        public void Add_Get_ActionCreated_Test()
        {
            try
            {
                var Method = base.type.GetMethod("Add", new Type[] { });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines Add action method");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check Add action method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

        [Test]
        public void Add_Post_ActionCreated_Test()
        {
            try
            {
                var Method = base.type.GetMethod("Add", new Type[] { typeof(VaccinationCenters) });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines Add action method which accepts over object as parameter");
                var attr = Method.GetCustomAttribute<HttpPostAttribute>();
                Assert.IsNotNull(attr, $"Add action is not marked with attributes to run on http post request in {base.type.Name} controller");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check Add action method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

        [Test]
        public void Search_Get_ActionCreated_Test()
        {
            try
            {
                var Method = base.type.GetMethod("Search", new Type[] { });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines Search action method");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check Search action method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

        [Test]
        public void Search_Post_ActionCreated_Test()
        {
            try
            {
                var Method = base.type.GetMethod("Search", new Type[] { typeof(SearchVaccinationCentersViewModel) });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines Search action method which accepts SearchVaccinationCentersViewModel object as parameter");
                var attr = Method.GetCustomAttribute<HttpPostAttribute>();
                Assert.IsNotNull(attr, $"Search action is not marked with attributes to run on http post request in {base.type.Name} controller");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check Search action method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

        [Test]
        public void Index_Get_ActionCreated_Test()
        {
            try
            {
                var Method = base.type.GetMethod("Index", new Type[] { });
                Assert.IsNotNull(Method, $"{base.type.Name} doesnot defines Index action method");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while check Index action method is present or not in {base.type.Name}. \nException message : {ex.InnerException?.Message} \nStack trace : {ex.InnerException.StackTrace}");
            }
        }

    }
}

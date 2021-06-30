using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CovidVaccinationCenterApp.Tests.TestExtensions;
using CovidVaccinationCenterApp.Models;

namespace CovidVaccinationCenterApp.Tests.Tests.StructuralTests
{
    [Order(2), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Models", "VaccinationCentersContext")]
    class VaccinationCentersContext_StructuralTests : TestBase
    {
        public VaccinationCentersContext_StructuralTests(string assemblyName, string namespaceName, string typeName) : base(assemblyName, namespaceName, typeName)
        {
        }

        [Test]
        public void DbSet_Property_CreationTest()
        {
            try
            {
                var IsFound = HasProperty("Centers", "DbSet`1");
                Assert.IsTrue(IsFound,
                              Messages.GetPropertyNotFoundMessage("Centers", "DbSet<VaccinationCenters>"));
            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, propertyName: "Centers"));
            }
        }

        [Test]
        public void InheritsFrom_DbContextTest()
        {
            Assert.AreEqual("DbContext", type.BaseType.Name, $"{base.type.Name} doesnot inherits from DbContext base class");
        }
    }
}

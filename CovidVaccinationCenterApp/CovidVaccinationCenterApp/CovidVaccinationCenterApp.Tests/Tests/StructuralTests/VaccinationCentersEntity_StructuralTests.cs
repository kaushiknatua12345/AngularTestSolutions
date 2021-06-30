using NUnit.Framework;
using CovidVaccinationCenterApp.Tests.TestExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DA = System.ComponentModel.DataAnnotations;

namespace CovidVaccinationCenterApp.Tests.Tests.StructuralTests
{
    [Order(1), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Models", "VaccinationCenters")]
    public class VaccinationCentersEntity_StructuralTests : TestBase
    {
        public VaccinationCentersEntity_StructuralTests(string assemblyName, string namespaceName, string typeName) 
            : base(assemblyName, namespaceName, typeName)
        {
        }

        [Test]
        public void PropertiesTest()
        {
            var CurrentProperty = new KeyValuePair<string, string>();
            try
            {
                var Properties = new Dictionary<string, string>
                {
                    { "Id", "Int32" },
                    { "VaccinationCenterName", "String" },
                    { "VaccineCategory", "String" },
                    { "StartDate", "DateTime" },
                    { "ContactMobileNo", "String" },
                    { "City", "String" }
                };
                foreach (var property in Properties)
                {
                    CurrentProperty = property;
                    var IsFound = HasProperty(property.Key, property.Value);
                    Assert.IsTrue(IsFound,
                                  Messages.GetPropertyNotFoundMessage(property.Key, property.Value));
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(Messages.GetExceptionMessage(ex, propertyName: CurrentProperty.Key));
            }
        }

        [Test]
        public void DataAnnotationsTest()
        {
            (string propertyname, string attributename) PropertyUnderTest = ("", "");
            try
            {
                PropertyUnderTest.propertyname = "Id";
                PropertyUnderTest.attributename = "Key";
                KeyAttributeTest();

                PropertyUnderTest.propertyname = "VaccinationCenterName";
                PropertyUnderTest.attributename = "Required";
                RequiredAttributeTest("Please provide vaccination center name");
                PropertyUnderTest.attributename = "StringLength";
                StringLengthAttributeTest("Vaccination center name cannot exceed 25 characters", 25);

                PropertyUnderTest.propertyname = "VaccineCategory";
                PropertyUnderTest.attributename = "Required";
                RequiredAttributeTest("Please provide vaccine category");
                PropertyUnderTest.attributename = "StringLength";
                StringLengthAttributeTest(maxLength: 30);


                PropertyUnderTest.propertyname = "ContactMobileNo";
                PropertyUnderTest.attributename = "Required";
                RequiredAttributeTest("Please provide mobile number");
                PropertyUnderTest.attributename = "StringLength";
                StringLengthAttributeTest(maxLength: 10);
                PropertyUnderTest.attributename = "RegularExpression";
                RegularExpressionAttributeTest("Please enter 10 digit mobile number");

                PropertyUnderTest.propertyname = "City";
                PropertyUnderTest.attributename = "Required";
                RequiredAttributeTest("Please provide city name");
                PropertyUnderTest.attributename = "StringLength";
                StringLengthAttributeTest("City name must not exceed 25 characters", 25);

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while testing {PropertyUnderTest.propertyname} for {PropertyUnderTest.attributename} attribute in {base.type.Name}");
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest.propertyname} of {base.type.Name} is not found";
                var attribute = GetAttributeFromProperty<DA.KeyAttribute>(PropertyUnderTest.propertyname, typeof(DA.KeyAttribute));
                Assert.IsNotNull(attribute, Message);
            }
            #endregion

            #region LocalFunction_RequiredAttributeTest
            void RequiredAttributeTest(string errorMessage)
            {
                string Message = $"Required attribute on {PropertyUnderTest.propertyname} of {base.type.Name} class doesnot have ";
                var attribute = GetAttributeFromProperty<DA.RequiredAttribute>(PropertyUnderTest.propertyname, typeof(DA.RequiredAttribute));
                Assert.IsNotNull(attribute, $"Required attribute not applied on {PropertyUnderTest.propertyname} of {base.type.Name} class");
                Assert.AreEqual(errorMessage, attribute.ErrorMessage, $"{Message} ErrorMessage={errorMessage}");
            }
            #endregion

            #region LocalFunction_StringLengthAttributeTest
            void StringLengthAttributeTest(string errorMessage = null, int? maxLength = null, int? minLength = null)
            {
                string Message = $"StringLength attribute on {PropertyUnderTest.propertyname} of {base.type.Name} class doesnot have ";
                var attribute = GetAttributeFromProperty<DA.StringLengthAttribute>(
                                                                            PropertyUnderTest.propertyname,
                                                                            typeof(DA.StringLengthAttribute));

                Assert.IsNotNull(attribute, $"StringLength attribute not applied on {PropertyUnderTest.propertyname} of {base.type.Name} class");

                if (errorMessage != null)
                    Assert.AreEqual(errorMessage, attribute.ErrorMessage, $"{Message} ErrorMessage={errorMessage}");
                if (maxLength != null)
                    Assert.AreEqual(maxLength.Value, attribute.MaximumLength, $"{Message} MaximumLength={errorMessage}");

                if (minLength != null)
                    Assert.AreEqual(minLength.Value, attribute.MinimumLength, $"{Message} MinimumLength={errorMessage}");
            }
            #endregion

            #region LocalFunction_RegularExpressionAttributeTest
            void RegularExpressionAttributeTest(string errorMessage)
            {
                string Message = $"RegularExpression attribute on {PropertyUnderTest.propertyname} of {base.type.Name} class doesnot have ";
                var attribute = GetAttributeFromProperty<DA.RegularExpressionAttribute>(
                                                        PropertyUnderTest.propertyname,
                                                        typeof(DA.RegularExpressionAttribute));
                Assert.IsNotNull(attribute, $"RegularExpression attribute not applied on {PropertyUnderTest.propertyname} of {base.type.Name} class");
                Assert.AreEqual(errorMessage, attribute.ErrorMessage, $"{Message} ErrorMessage={errorMessage}");
            }
            #endregion
        }
    }
}

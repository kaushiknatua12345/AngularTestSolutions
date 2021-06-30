﻿using NUnit.Framework;
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
    [Order(3), TestFixture("CovidVaccinationCenterApp", "CovidVaccinationCenterApp.Models", "SearchVaccinationCentersViewModel")]
    public class SearchVaccinationCentersViewModel_StructuralTests : TestBase
    {
        public SearchVaccinationCentersViewModel_StructuralTests(string assemblyName, string namespaceName, string typeName) : base(assemblyName, namespaceName, typeName)
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
                    { "VaccineCategory", "String" },
                    { "City", "String" },
                    { "Centers","List`1" }
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
                PropertyUnderTest.propertyname = "VaccineCategory";
                PropertyUnderTest.attributename = "Required";
                RequiredAttributeTest("Please provide Vaccine Category to search");

                PropertyUnderTest.propertyname = "City";
                PropertyUnderTest.attributename = "Required";
                RequiredAttributeTest("Please provide city name to search");
                PropertyUnderTest.attributename = "StringLength";
                StringLengthAttributeTest("City name must not exceed 25 characters", 25);

            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception while testing {PropertyUnderTest.propertyname} for {PropertyUnderTest.attributename} attribute in {base.type.Name}");
            }

            

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

            
        }
    }
}

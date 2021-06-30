using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationCenterApp.Tests.TestExtensions
{
    public class AssertFailureMessages
    {
        private string TypeName;
        public AssertFailureMessages(string typeName)
        {
            this.TypeName = typeName;
        }
        public string GetAssemblyNotFoundMessage(string assemblyName)
        {
            return $"Could not find {assemblyName}.dll";
        }
        public string GetTypeNotFoundMessage(string assemblyName, string typeName = null)
        {
            return $"Could not find {typeName ?? TypeName} in  {assemblyName}.dll";
        }
        public string GetFieldNotFoundMessage(string fieldName, string fieldType, string typeName = null)
        {
            return $"Could not a find public field {fieldName} of {fieldType} type in {typeName ?? TypeName} class";
        }
        public string GetPropertyNotFoundMessage(string propertyName, string propertyType, string typeName = null)
        {
            return $"Could not a find public property {propertyName} of {propertyType} type in {typeName ?? TypeName} class";
        }
        public string GetFieldTypeMismatchMessage(string fieldName, string expectedFieldType, string typeName = null)
        {
            return $"{fieldName} is not of {expectedFieldType} data type in {typeName ?? TypeName} class";
        }
        public string GetExceptionTestFailureMessage(string methodName, string customExceptionTypeName, string propertyName, Exception exception, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot throws exception of type {customExceptionTypeName} on validation failure for {propertyName}.\nException Message: {exception.InnerException?.Message}\nStack Trace:{exception.InnerException?.StackTrace}";
        }

        public string GetExceptionMessage(Exception ex, string methodName = null, string fieldName = null, string propertyName = null, string typeName = null)
        {
            string testFor = methodName != null ? methodName + " method" : fieldName != null ? fieldName + " field" : propertyName != null ? propertyName + " property" : "undefined";
            return $" Exception while testing {testFor} of {typeName ?? TypeName} class.\nException message : {ex.InnerException?.Message}\nStack Trace : {ex.InnerException?.StackTrace}";
        }

        public string GetReturnTypeAssertionFailMessage(string methodName, string expectedTypeName, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return value of {expectedTypeName} data type";
        }
        public string GetReturnValueAssertionFailMessage(string methodName, object expectedValue, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName } class doesnot return the value {expectedValue}";
        }

        public string GetValidationFailureMessage(string methodName, string expectedValidationMessage, string propertyName, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return '{expectedValidationMessage}' on validation failure for property {propertyName}";
        }

    }
}

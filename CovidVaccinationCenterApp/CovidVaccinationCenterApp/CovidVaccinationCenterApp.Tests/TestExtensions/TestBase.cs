using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationCenterApp.Tests.TestExtensions
{
    public abstract class TestBase
    {
        protected readonly AssertFailureMessages Messages;

        protected readonly string assemblyName;
        protected readonly string namespaceName;
        protected readonly string typeName;

        protected Assembly assembly;
        protected Type type;

        public TestBase(string assemblyName, string namespaceName, string typeName)
        {
            Messages = new AssertFailureMessages(typeName);
            this.assemblyName = assemblyName;
            this.namespaceName = namespaceName;
            this.typeName = typeName;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            assembly = Assembly.Load(assemblyName);
            type = assembly.GetType($"{namespaceName}.{typeName}");

            Assert.IsNotNull(assemblyName,
                             Messages.GetAssemblyNotFoundMessage(assemblyName));
            Assert.IsNotNull(typeName,
                             Messages.GetTypeNotFoundMessage(assemblyName));
        }
        protected object typeInstance = null;
        protected void CreateNewTypeInstance()
        {
            typeInstance = assembly.CreateInstance(type.FullName);
        }
        protected object GetTypeInstance()
        {
            if (typeInstance == null)
                CreateNewTypeInstance();
            return typeInstance;
        }
        protected object InvokeMethod(string methodName, Type type, params object[] parameters)
        {
            var method = type.GetMethod(methodName);
            var instance = GetTypeInstance();
            var result = method.Invoke(instance, parameters);
            return result;
        }
        protected T InvokeMethod<T>(string methodName, Type type, params object[] parameters)
        {
            var result = InvokeMethod(methodName, type, parameters);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        protected bool HasField(string fieldName, string fieldType)
        {
            bool Found = false;
            var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (field != null)
            {
                Found = field.FieldType.Name == fieldType;
            }
            return Found;
        }

        protected bool HasProperty(string propertyName, string propertyType)
        {
            bool Found = false;
            var property = type.GetProperty(propertyName);
            if (property != null)
            {
                Found = property.PropertyType.Name == propertyType; ;
            }
            return Found;
        }

        protected T GetAttributeFromProperty<T>(string propertyName, Type attribute)
        {

            var attr = type.GetProperty(propertyName).GetCustomAttribute(attribute, false);
            return (T)Convert.ChangeType(attr, typeof(T));
        }
    }
}

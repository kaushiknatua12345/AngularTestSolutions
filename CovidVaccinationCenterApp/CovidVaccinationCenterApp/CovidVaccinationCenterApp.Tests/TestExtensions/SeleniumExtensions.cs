using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationCenterApp.Tests.TestExtensions
{
    public static class SeleniumExtensions
    {

        public static void SetElementText(this IWebDriver driver, string elementId, string text)
        {
            var Element = driver.FindElement(By.Id(elementId));
            Element.Clear();
            Element.SendKeys(text);
        }

        public static string GetElementText(this IWebDriver driver, string elementId)
        {
            return driver.GetElementText(elementId);
        }

        public static void ClickElement(this IWebDriver driver, string elementId)
        {
            driver.FindElement(By.Id(elementId)).Click();
        }

        public static void SelectDropDownItemByValue(this IWebDriver driver, string elementId, string value)
        {
            new SelectElement(driver.FindElement(By.Id(elementId))).SelectByValue(value);
        }
        public static void SelectDropDownItemByText(this IWebDriver driver, string elementId, string text)
        {
            new SelectElement(driver.FindElement(By.Id(elementId))).SelectByText(text);
        }
       

        public static string GetElementInnerText(this IWebDriver driver, string elementType, string attribute)
        {
            return driver.FindElement(By.XPath($"//{elementType}[{attribute}]")).GetAttribute("innerHTML");
        }

        public static int GetTableRowsCount(this IWebDriver driver, string elementId)
        {
            var Table = driver.FindElement(By.Id(elementId));
            return Table.FindElements(By.TagName("tr")).Count;
        }

    }
}

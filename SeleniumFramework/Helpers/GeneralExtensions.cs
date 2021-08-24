namespace SeleniumFramework.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class GeneralExtensions
    {
        /// <summary>
        /// Gets the description attribute of the enum.
        /// </summary>
        /// <param name="currentEnum">The current enum.</param>
        /// <returns>A string of the description attribute.</returns>
        public static string ToDescription(this Enum currentEnum)
        {
            FieldInfo fieldInfo = currentEnum.GetType().GetField(currentEnum.ToString());
            System.ComponentModel.DescriptionAttribute[] attributes = (System.ComponentModel.DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            return attributes.Length > 0
                ? attributes[0].Description
                : currentEnum.ToString();
        }

        /// <summary>
        /// Gets all the description attributes of an enum.
        /// </summary>
        /// <param name="enumType">The typeof the enum to iterate through.</param>
        /// <returns>A list of all the enum's description attributes as strings.</returns>
        public static List<string> GetDescriptions(Type enumType)
        {
            return Enum.GetValues(enumType)
                .Cast<Enum>()
                .Select(val => val.ToDescription())
                .ToList();
        }

        /// <summary>
        /// Asserts that each element in a collection was displayed.
        /// </summary>
        /// <param name="collection">The collection to check against.</param>
        public static void EachItemDisplays(this IReadOnlyCollection<IWebElement> collection)
        {
            foreach (var element in collection.Select((value, index) => new { value, index }))
            {
                Assert.IsTrue(
                    element.value.Displayed,
                    $"Element at index {element.index} was not displayed.");
            }
        }

        /// <summary>
        /// Asserts that each element is required.
        /// </summary>
        /// <param name="collection">The collection to check against.</param>
        public static void EachItemIsRequired(this IReadOnlyCollection<IWebElement> collection)
        {
            foreach (var element in collection.Select((value, index) => new { value, index }))
            {
                Assert.IsTrue(
                    element.value.Required(),
                    $"Element at index {element.index} was not required.");
            }
        }

        public static void WaitForPageLoad(this IWebDriver driver) =>
            WaitFor(driver, (driver) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

        public static void WaitFor(this IWebDriver driver, Func<IWebDriver, bool> waitOn, double timeout = 5, double pollingInterval = 0.5, string errorMessage = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
            {
                PollingInterval = TimeSpan.FromSeconds(pollingInterval),
                Message = errorMessage ?? string.Empty,
            };

            wait.Until(waitOn);
        }
    }
}

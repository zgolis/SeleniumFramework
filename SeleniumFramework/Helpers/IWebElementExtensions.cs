namespace SeleniumFramework.Helpers
{
    using OpenQA.Selenium;

    public static class IWebElementExtensions
    {
        /// <summary>
        /// Gets the value of the required attribute for this element.
        /// </summary>
        /// <param name="element">The element to get the attribute from.</param>
        /// <returns>A bool whether the required attribute was found or not.</returns>
        public static bool Required(this IWebElement element) => element.GetAttribute("required") != null;

        /// <summary>
        /// Gets the value of the value attribute for this element.
        /// </summary>
        /// <param name="element">The element to get the attribute from.</param>
        /// <returns>A string of the value attribute.</returns>
        public static string Value(this IWebElement element) => element.GetAttribute("value");
    }
}

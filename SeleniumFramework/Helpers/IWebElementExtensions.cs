namespace SeleniumFramework.Helpers
{
    using OpenQA.Selenium;

    public static class IWebElementExtensions
    {
        public static bool Required(this IWebElement element) => element.GetAttribute("required") != null;

        public static string Value(this IWebElement element) => element.GetAttribute("value");

        public static string Placeholder(this IWebElement element) => element.GetAttribute("placeholder");
    }
}

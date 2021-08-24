namespace SeleniumFramework.PageActions
{
    using OpenQA.Selenium;

    public class BasePageActions
    {
        public BasePageActions(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Gets the current driver.
        /// </summary>
        public IWebDriver Driver { get; }
    }
}

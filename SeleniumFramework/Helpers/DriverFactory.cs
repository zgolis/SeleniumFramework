namespace SeleniumFramework.Helpers
{
    using OpenQA.Selenium.Chrome;

    public class DriverFactory
    {
        /// <summary>
        /// Gets a maximized chrome driver.
        /// </summary>
        /// <returns>A Chrome Driver.</returns>
        public static ChromeDriver Driver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            return new ChromeDriver(options);
        }
    }
}

namespace SeleniumFramework.Helpers
{
    using OpenQA.Selenium.Chrome;

    public class DriverFactory
    {
        public static ChromeDriver Driver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            return new ChromeDriver(options);
        }
    }
}

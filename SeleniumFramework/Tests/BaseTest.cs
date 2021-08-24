namespace SeleniumFramework.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using SeleniumFramework.Helpers;

    [TestClass]
    public class BaseTest
    {
        public static IWebDriver Driver { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Driver = DriverFactory.Driver();
            this.Initialize();
        }

        public virtual void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Close();
                Driver.Quit();
            }
        }
    }
}
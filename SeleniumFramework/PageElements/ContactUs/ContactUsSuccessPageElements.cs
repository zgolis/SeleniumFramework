namespace SeleniumFramework.PageElements.ContactUs
{
    using OpenQA.Selenium;

    public class ContactUsSuccessPageElements : BasePageElements
    {
        public const string SuccessText = "Thank you for your interest! Once we review your request a representative will be in contact with you.";

        public ContactUsSuccessPageElements(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement TextSuccess => this.Driver.FindElement(By.XPath("//p"));

        public IWebElement LinkBack => this.Driver.FindElement(this.ByLink("Back"));
    }
}

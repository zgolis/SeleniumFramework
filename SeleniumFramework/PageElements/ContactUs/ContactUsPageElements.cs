namespace SeleniumFramework.PageElements.ContactUs
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class ContactUsPageElements : BasePageElements
    {
        public ContactUsPageElements(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement HeaderContactUs => this.Driver.FindElement(By.XPath("//h2[normalize-space()='Contact Us']"));

        public IWebElement InputFirstName => this.Driver.FindElement(this.ByLabelFollowingInput("First name"));

        public IWebElement InputLastName => this.Driver.FindElement(this.ByLabelFollowingInput("Last name"));

        public IWebElement InputEmail => this.Driver.FindElement(this.ByLabelFollowingInput("Email"));

        public IWebElement InputAddress => this.Driver.FindElement(this.ByLabelFollowingInput("Address"));

        public IWebElement InputAddressTwo => this.Driver.FindElement(this.ByLabelFollowingInput("Address 2 (Optional)"));

        public SelectElement DropdownCountry => new SelectElement(this.Driver.FindElement(this.ByLabelFollowingInput("Country", "Select")));

        public SelectElement DropdownState => new SelectElement(this.Driver.FindElement(this.ByLabelFollowingInput("State", "Select")));

        public IWebElement InputZip => this.Driver.FindElement(this.ByLabelFollowingInput("Zip"));

        public IWebElement ButtonSubmit => this.Driver.FindElement(this.ByButton("Submit"));

        public List<IWebElement> TextsInvalidFeedback => this.Driver.FindElements(By.XPath("//div[@class='invalid-feedback']")).ToList();

        public IReadOnlyCollection<IWebElement> Elements => new[]
        {
            this.HeaderContactUs,
            this.InputFirstName,
            this.InputLastName,
            this.InputEmail,
            this.InputAddress,
            this.InputAddressTwo,
            this.DropdownCountry.WrappedElement,
            this.DropdownState.WrappedElement,
            this.InputZip,
            this.ButtonSubmit,
        };

        public IReadOnlyCollection<IWebElement> RequiredElements => new[]
        {
            this.InputFirstName,
            this.InputLastName,
            this.InputEmail,
            this.InputAddress,
            this.DropdownCountry.WrappedElement,
            this.DropdownState.WrappedElement,
            this.InputZip,
        };

        public string Slug => "https://interview-contact-us.azurewebsites.net/";
    }
}

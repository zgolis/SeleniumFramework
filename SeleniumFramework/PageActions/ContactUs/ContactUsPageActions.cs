namespace SeleniumFramework.PageActions.ContactUs
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using SeleniumFramework.Helpers;
    using SeleniumFramework.PageElements.ContactUs;
    using static SeleniumFramework.Information.ContactUs.ContactUs;

    public class ContactUsPageActions : BasePageActions
    {
        private ContactUsPageElements contactUs;

        public ContactUsPageActions(IWebDriver driver)
            : base(driver)
        {
            this.contactUs = new ContactUsPageElements(this.Driver);
        }

        public ContactUsPageActions AddUserInfo(UserInfo info)
        {
            this.contactUs.InputFirstName.SendKeys(info.FirstName);
            this.contactUs.InputLastName.SendKeys(info.LastName);
            this.contactUs.InputEmail.SendKeys(info.Email);
            this.contactUs.InputAddress.SendKeys(info.Address);

            if (!string.IsNullOrEmpty(info.AddressTwo))
            {
                this.contactUs.InputAddressTwo.SendKeys(info.AddressTwo);
            }

            this.contactUs.DropdownCountry.SelectByText(info.Country.ToDescription());
            this.contactUs.DropdownState.SelectByText(info.State.ToDescription());
            this.contactUs.InputZip.SendKeys(info.Zip);

            return this;
        }

        public ContactUsPageActions VerifyUserInfo(UserInfo info)
        {
            Assert.AreEqual(info.FirstName, this.contactUs.InputFirstName.Value());
            Assert.AreEqual(info.LastName, this.contactUs.InputLastName.Value());
            Assert.AreEqual(info.Email, this.contactUs.InputEmail.Value());
            Assert.AreEqual(info.Address, this.contactUs.InputAddress.Value());

            if (!string.IsNullOrEmpty(info.AddressTwo))
            {
                Assert.AreEqual(info.AddressTwo, this.contactUs.InputAddressTwo.Value());
            }

            Assert.AreEqual(info.Country.ToDescription(), this.contactUs.DropdownCountry.SelectedOption.Text);
            Assert.AreEqual(info.State.ToDescription(), this.contactUs.DropdownState.SelectedOption.Text);
            Assert.AreEqual(info.Zip, this.contactUs.InputZip.Value());

            return this;
        }
    }
}

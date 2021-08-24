namespace SeleniumFramework.Tests.ContactUs
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SeleniumFramework.Helpers;
    using SeleniumFramework.PageActions.ContactUs;
    using SeleniumFramework.PageElements.ContactUs;
    using SeleniumFramework.Tests;
    using static SeleniumFramework.Information.ContactUs.ContactUs;

    [TestClass]
    public class ContactUs : BaseTest
    {
        private ContactUsPageElements contactUs;
        private ContactUsSuccessPageElements contactUsSuccess;
        private ContactUsPageActions contactUsActions;

        public override void Initialize()
        {
            this.contactUs = new ContactUsPageElements(Driver);
            this.contactUsSuccess = new ContactUsSuccessPageElements(Driver);
            this.contactUsActions = new ContactUsPageActions(Driver);

            Driver.Navigate().GoToUrl(this.contactUs.Slug);
        }

        [TestMethod]
        public void ContactUs_Required()
        {
            Driver.WaitForPageLoad();
            this.contactUs.Elements.EachItemDisplays();
            this.contactUs.RequiredElements.EachItemIsRequired();

            Assert.IsTrue(
                this.contactUs.TextsInvalidFeedback.Any(feedbackElements => !feedbackElements.Displayed),
                "There were invalid feedback text displayed before the submit button was clicked.");

            this.contactUs.ButtonSubmit.Click();

            Assert.AreEqual(7, this.contactUs.TextsInvalidFeedback.Count);

            CollectionAssert.AreEqual(
                GeneralExtensions.GetDescriptions(typeof(RequiredAlertText)),
                this.contactUs.TextsInvalidFeedback.Select(invalidFeedbackElement => invalidFeedbackElement.Text).ToList());
        }

        [TestMethod]
        public void ContactUs_Validate()
        {
            Driver.WaitForPageLoad();
            this.contactUs.Elements.EachItemDisplays();

            CollectionAssert.AreEqual(
                GeneralExtensions.GetDescriptions(typeof(CountryOptions)),
                this.contactUs.DropdownCountry.Options.Select(element => element.Text).ToList());

            CollectionAssert.AreEqual(
                GeneralExtensions.GetDescriptions(typeof(StateOptions)),
                this.contactUs.DropdownState.Options.Select(element => element.Text).ToList());
        }

        [TestMethod]
        public void ContactUs_Verify()
        {
            Driver.WaitForPageLoad();
            var testUser = TestUser;

            this.contactUsActions
                .AddUserInfo(testUser)
                .VerifyUserInfo(testUser);

            var previousUrl = Driver.Url;

            this.contactUs.ButtonSubmit.Click();
            Driver.WaitForPageLoad();

            Assert.AreNotEqual(previousUrl, Driver.Url);

            Assert.AreEqual(
                ContactUsSuccessPageElements.SuccessText,
                this.contactUsSuccess.TextSuccess.Text);

            this.contactUsSuccess.LinkBack.Click();
            Driver.WaitForPageLoad();

            Assert.AreEqual(previousUrl + "Home/Index", Driver.Url);
        }
    }
}

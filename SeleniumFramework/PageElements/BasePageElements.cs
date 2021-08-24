namespace SeleniumFramework.PageElements
{
    using OpenQA.Selenium;

    public class BasePageElements
    {
        public BasePageElements(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Gets the current driver.
        /// </summary>
        public IWebDriver Driver { get; }

        /// <summary>
        /// Gets an input following a specific label.
        /// </summary>
        /// <param name="labelText">The label's text to search for.</param>
        /// <param name="endingTag">The following element's ending tag.</param>
        /// <returns>A By to to find the following tag after the label.</returns>
        public By ByLabelFollowingInput(string labelText, string endingTag = "input") =>
            By.XPath($"//label[normalize-space()='{labelText}']/following-sibling::{endingTag}");

        /// <summary>
        /// Gets a button based on its text.
        /// </summary>
        /// <param name="buttonText">The buttons's text to search for.</param>
        /// <returns>A By to to find the button.</returns>
        public By ByButton(string buttonText) =>
            By.XPath($"//button[normalize-space()='{buttonText}']");

        /// <summary>
        /// Gets a link based on its text.
        /// </summary>
        /// <param name="linkText">The link's text to search for.</param>
        /// <returns>A By to to find the link.</returns>
        public By ByLink(string linkText) =>
            By.XPath($"//a[normalize-space()='{linkText}']");
    }
}
namespace SeleniumFramework.Information.ContactUs
{
    using System.ComponentModel;

    public class ContactUs
    {
        public enum RequiredAlertText
        {
            [Description("Valid first name is required.")]
            FirstName,
            [Description("Valid last name is required.")]
            LastName,
            [Description("Please enter a valid email address for shipping updates.")]
            Email,
            [Description("Please enter your shipping address.")]
            Address,
            [Description("Please select a valid country.")]
            Country,
            [Description("Please provide a valid state.")]
            State,
            [Description("Zip code required.")]
            Zip,
        }

        public enum CountryOptions
        {
            [Description("Choose...")]
            Choose,
            [Description("United States")]
            UnitedStates,
        }

        public enum StateOptions
        {
            [Description("Choose...")]
            Choose,
            [Description("California")]
            California,
            [Description("Minnesota")]
            Minnesota,
        }

        /// <summary>
        /// Gets Generic User info.
        /// </summary>
        public static UserInfo TestUser => new UserInfo(
            firstName: "Test",
            lastName: "Random",
            email: "test.random@email.com",
            address: "123 Test Road",
            addressTwo: "Apt #321",
            country: CountryOptions.UnitedStates,
            state: StateOptions.California,
            zip: "12345");

        /// <summary>
        /// A struct of User Info.
        /// </summary>
        public struct UserInfo
        {
            public string FirstName;
            public string LastName;
            public string Email;
            public string Address;
            public string AddressTwo;
            public CountryOptions Country;
            public StateOptions State;
            public string Zip;

            public UserInfo(
                string firstName,
                string lastName,
                string email,
                string address,
                CountryOptions country,
                StateOptions state,
                string zip,
                string addressTwo = null)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Email = email;
                this.Address = address;
                this.Country = country;
                this.State = state;
                this.Zip = zip;
                this.AddressTwo = addressTwo;
            }
        }
    }
}

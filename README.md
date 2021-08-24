# SeleniumFramework

This is a generic test framework based on a Contact Us page.



### Steps / Expected Results:

## Test Case 1: ContactUs_Required

1. Navigate to 'Contact Us' page
E. Page loads with required items displayed and required and no invalid feedback text is displayed.

2. Click the submit button.
E. Invalid feedback text is displayed for all but Address 2.

3. Verify each invalid feedback text is present with text that matches.
E. Invalid feedback text displays correctly.

## Test Case 2: ContactUs_Validate
1. Navigate to 'Contact Us' page.
E. Page loads with a header, 6 input fields, 2 selects and 1 button to submit displayed.

2. Validate both selects contain all their options.
E. Country select has 2 options and State has three options and each are displayed correctly.

## Test Case 3: ContactUs_Verify
1. Navigate to 'Contact Us' page.
E. Page loads.

2. Fill out all available fields.
E. Each field displays the correctly inputted information.

3. Click the submit button.
E. New page loads with specific success text.

4. Click the 'Back' link.
E. Previous page loads.

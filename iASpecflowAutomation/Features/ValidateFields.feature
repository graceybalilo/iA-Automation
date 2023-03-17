Feature: ValidateFields

Check validation for input fields

@Check
Scenario: No selections made in About you page
	Given I am on Industrial Alliance Website
	And I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I did not select anything from the list of questions about myself
	And I did not answer the question about my insurance coverage
	And I click the Calculate button
	Then I should see an error message saying Please make a selection

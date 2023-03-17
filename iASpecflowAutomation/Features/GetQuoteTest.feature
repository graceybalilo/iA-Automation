Feature: GetQuoteTest

Get a Quote and select housing insurance

@Regression
Scenario: Get a Quote for home Insurance
	Given I am on iA homepage
	When I click the Get a Quote button
	And I select the home Insurance from the dropdown
	Then the pop-up message for housing insurance will be displayed

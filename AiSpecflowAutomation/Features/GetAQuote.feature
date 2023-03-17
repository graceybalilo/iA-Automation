Feature: GetAQuote

This feature navigates to iA (Insutrial Alliance) website, gets a quote and calculate possible life insurance amount and cost

@Test
Scenario: Get a Quote for Women - Couple
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for calculating my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs

	Examples: 
	| BirthDate  | Amount      |
	| 02-05-1998 | 25000       |


@Test
Scenario: Get a Quote for Women - Single non Smoker
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for single woman and calculate my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs
	Examples: 
	| BirthDate  | Amount      |
	| 01-05-1998 | 26000       |
	
@Test
Scenario: Get a Quote for Women - Single Smoker
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for single smoker woman and calculate my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs
	Examples: 
	| BirthDate  | Amount      |
	| 01-05-1988 | 30000       |


@Test
Scenario: Get a Quote for Man - Single Smoker
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for single smoker man and calculate my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs
	Examples: 
	| BirthDate  | Amount      |
	| 01-05-1988 | 30000       |


@Test
Scenario: Get a Quote for Man - Single Non Smoker
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for single non smoker man and calculate my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs
	Examples: 
	| BirthDate  | Amount      |
	| 01-05-1988 | 30000       |

@Test
Scenario: Get a Quote for Man - Couple Smoker
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for couple smoker man and calculate my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs
	Examples: 
	| BirthDate  | Amount      |
	| 01-05-1988 | 30000       |

	@Test
Scenario: Get a Quote for Man - Couple non Smoker
	Given I am on Industrial Alliance Website
	When I click the Get a Quote button
	And I select Life Insurance from the dropdown list
	And I click Determine your Needs from the pop-up
	And I click the needed fields for couple non smoker man and calculate my term life insurance
	And I populate the required fields on the page using "<BirthDate>", "<Amount>"
	When I click the Calculate button
	Then I should be able to see the calculation of my insurance based from my inputs
	Examples: 
	| BirthDate  | Amount      |
	| 01-05-1988 | 30000       |
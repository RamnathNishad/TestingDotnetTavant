Feature: Amazon Search Functionality

A short summary of the feature

@tag1
Scenario: Product Search by name
	Given I have search field on Amazon page
	When I search for "laptop"
	Then I expect a "laptop" related resuls

Feature: Calculator

As a user
I want to perform basic arithematic operations

@tag1
Scenario: Add two numbers
	Given I have opened the calculator
	And I have entered 5 
	And I have entered 3
	When I press the equals button
	Then The result should be 8
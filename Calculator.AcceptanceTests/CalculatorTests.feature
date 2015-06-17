Feature: CalculatorTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add two numbers
	Given the calculator exe is running
	When I enter 70
	And I enter 30
	And I enter +
	Then the result should be
	"""
	30 + 70 = 100
	Stack: 100
	"""

Scenario: Add three numbers
	Given the calculator exe is running
	When I enter 70
	And I enter 20
	And I enter 50
	And I enter +
	Then the result should be
	"""
	50 + 20 = 70
	Stack: 70, 70
	"""
	When I enter +
	Then the result should be
	"""
	70 + 70 = 140
	Stack: 140
	"""

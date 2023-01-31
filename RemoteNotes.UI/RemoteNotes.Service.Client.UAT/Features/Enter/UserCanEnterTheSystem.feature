Feature: UserCanEnterTheSystem
	In order to enter the system
	As a user
	I want to be able to enter the system
@positive
Scenario: Customer can enter the system
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
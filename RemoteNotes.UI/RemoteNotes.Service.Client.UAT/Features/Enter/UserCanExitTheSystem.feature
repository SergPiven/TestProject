Feature: UserCanExitTheSystem
	In order to reduce unsanction access risk
	As a user
	I want to be able to exit the system (make system logout)
@positive
Scenario: User can exit the system
	Given I try to connect to the service
	When the result should be connected successfully
	When I enter the login: login and password: password
	When I try to exit the system
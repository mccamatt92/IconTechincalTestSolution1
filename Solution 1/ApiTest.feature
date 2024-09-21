@Users
Feature: ApiTest

As a user I want that I am able to access the API and return data correctly

Scenario Outline: Check Users Data
	Given I have the API endpoint
	When I send a request for page <Page>
	Then The response is successful
	And the response should contain <Users> users
	And the page matches with <Page>
	And the user details should be:
	| First Name  | Last Name  | Email   | Avatar   |
    | <FirstName> | <LastName> | <Email> | <Avatar> |

	Examples: 
	|TestId |Page |Users | FirstName | LastName  | Email                  | Avatar                                   |
	|1      |1    |6	 | Janet     | Weaver    | janet.weaver@reqres.in | https://reqres.in/img/faces/2-image.jpg  |
	|2      |2    |6	 | Byron     | Fields    | byron.fields@reqres.in | https://reqres.in/img/faces/10-image.jpg |

Scenario: Check No Users Are Returned
	Given I have the API endpoint
	When I send a request for page 12
	Then The response is successful
	And no users should be returned
	And the page matches with 12

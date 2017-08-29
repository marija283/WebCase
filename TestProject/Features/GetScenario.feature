Feature: GetScenario
	Scenario for creating user, getting user
	modifying user and deleting user.

@mytag
Scenario Outline: CreateGetModifyDeleteUser
	Given Stated the test
	Then I create case with caseName <caseName> and kind <kind>
	Then Get created user with
	#And Modify contact
	#Then Get modified contact
	

Examples:
	| caseName   | kind   |
	| "casename" | "kind" |


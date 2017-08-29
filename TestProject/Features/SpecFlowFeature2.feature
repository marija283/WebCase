Feature: CaseGetById
	

Background:
	Given the following cases
		| id | caseNmber | kind | customerNumer | attachment        |
		| 1  | 123       | nice | 456           | NULL              |
		| 2  | NULL      | NULL | NULL          | NULL              |
		| 3  | 1223      | 132  | 555           | attachments/3.pdf |




@mytag
Scenario: GetCase
	#Given I have entered 50 into the calculator
	#And I have entered 70 into the calculator
	When I search for cases by the 'id'
	Then the list of found books should be:
		| id | caseNmber | kind | customerNumer | attachment        |
		| 1  | 123       | nice | 456           | NULL              |
Feature: GetCaseById

@mytag
Scenario Outline: Get case by id
 Given Started the test
 Then Get case by <ID>

@source:TestCases.xlsx

Examples:
| ID |
| 1  |
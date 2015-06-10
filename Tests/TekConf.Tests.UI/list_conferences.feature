Feature: List Conferences
  I want to be able to see upcoming conferences

@listConferences
  Scenario: Add a task
    Given I am on the conferences list screen
	When The conferences list is visible
	Then conference listings are available
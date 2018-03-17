Feature: PollFormFeature	 
@pollform
Scenario: As User I vote on poll box
	Given I enter to poll page
	When I check view of poll form
	And I add vote
	Then Check amount of votes
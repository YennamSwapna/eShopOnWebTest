Feature: Login
	Login to eShop On Web site

@smoke
Scenario: Perform successful Login of eShop On Web site
	Given I launch the application
	And I click on Login link
	And I enter the following details
	 | Email                       | Password      |
	 |  demouser@microsoft.com     | Pass@word1    |
	When I click on Login Button
	Then the dashboard screen is displayed

Scenario: Perform invalid Login of eShop On Web site
	Given Launch the application
	And Click on Login link
	And Enter the following details
	 | Email                       | Password      |
	 |  demouser@microsoft.com     | Pass@word2    |
	When I click Login Button
	Then Invalid message is displayed
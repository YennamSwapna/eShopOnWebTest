Feature: OrderProduct
	Order a Product

@order
Scenario: Order a Product as a user
	Given launch the application
	And click on Login link
	And enter the following details
	 |  Email                      | Password      |
	 |  demouser@microsoft.com     | Pass@word1    |
	And click Login Button
	And select a brand Other from the Catalog page
	And click the arrow right
	And select a product
	And provide valid quantity
	|  Quantity  | 
	|  2         | 
	And click Checkout
	When click PayNow
	Then confirmation message is displayed
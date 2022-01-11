Feature: OrderAnItem

User logs in, selects an item from the shop and adds to cart, 
goes to checkout, applies a coupon and places an order, finally 
verifying the order number in my accounts

Background: Logging into shop
Given I log in using 'peter.deng@nfocus.co.uk' and 'Q8UGRr2K27ZW2hJ'
@tag1
Scenario: Apply a discount and order an item from the shop
	Given I am logged into my account
	When I purchase an item
	And I use a discount code 'edgewords'
	Then discount is applied
	When I checkout
	Then the order displays in my account
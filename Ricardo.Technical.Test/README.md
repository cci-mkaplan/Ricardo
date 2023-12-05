# Ricardo

Ricardo Technical Test

Scenario:
Changes on the project:
-	The Shop needs to record its stock so that it doesn’t sell items it doesn’t have any more.(that has been done by adding the stock class into the project and seperating items info and stock insntances indipendently)
-	Customers have been asking to see their order history while they are logged in.  (If u look at top right corner u will see the full history of the purchases)
-	Customers should be able to sign out of the application. (If u hover up the location that u signed in, u will see the button for signing out)
-	Customers want to be able to remove things from their basket. (Customer can remove the thing from their basket. A new button  has been added to do this. )


Improvements: 
- There was no money check in the applicaton. It's hanled by catching the InsufficientFundsException and showing customer a proper message. 
- there was no stock check after adding the item. If current basket holds some of the same item and customer wants to add more inorder to reach the amount limit of the stock, the UI now gives the error of 
`The amount of the item (x) still in the basket and the amount of item u wanted to add (y) into basket can not be more than the stock (z)!`
- Customer can add the item for the first time if stock amount is less then their desired one. A proper message shows up an  informs the customer. 
- In a production web site, the purhesing and removing the stock item operations must be in a tracnsaction in a way to catch and revert them if anything fails on the one go. But here its not implemented as there is a unit of work neended. 
- Removing stock operation was put under a lockking mechanizm to prevent other treads to receach them and change the it at the same time. So, concurrency management is partially implemented. 
- There is a bunit integration test project (a testing framawork for a blazor project) is added to the solution to help test some mainingfull testing scenarios to make sure screens are working as expected. 
(I have changed some properties and injection items to public to test it. 
It may not appropriate but there was no way to test it. Normally we should use the interfaces to test mock dependencies. Here Navigation used as INavigation to mock some testing scenarios.) 


--Tested scenarios
* An item can be instered to the basket
* An item can be removed to the basket
* An Item can be purchased with sufficient funds in the account. 
* An Item can not be purchased with Insufficient funds in the account.

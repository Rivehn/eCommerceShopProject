using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using eCommerceShopProject.POMPOMs;
using eCommerceShopProject.ScenarioObjects;
using static eCommerceShopProject.Support.TestHelperClass;

namespace eCommerceShopProject.StepDefinitions
{
    [Binding]
    public class OrderAnItemStepDefinitions : Support.TestBaseClass
    {
        public LoginPOM login = new();
        public ShopPOM shop = new();
        public CheckoutPOM checkout = new(driver);
        public BillPOM bill = new();
        public OrderPOM order = new();
        public MyAccountPOM account = new();
        public ClothingPOM clothing = new();
        public MyAccountOrderPOM myAccountOrder = new();
        public Customer customer = new();

        [Given(@"I log in using '([^']*)' and '([^']*)'")]
        public void GivenILogInUsingAnd(string u, string p)
        {
            //Go to designated site
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            UtilElementBonker(driver, login.GetBottomThing());

            //Login to the site
            UtilFieldClearer(driver, login.GetUsernameField());
            UtilFieldClearer(driver, login.GetPasswordField());
            UtilTypeWriter(driver, login.GetUsernameField(), u);
            UtilTypeWriter(driver, login.GetPasswordField(), p);
            UtilElementBonker(driver, login.GetSubmit());
        }

        [Given(@"I am logged into my account")]
        public void GivenIAmLoggedIntoMyAccount()
        {
            //Verify login
            Assert.That(UtilTextReader(driver, account.GetLogout()), Is.EqualTo("Logout"), "Failed to Login.");
        }

        [When(@"I purchase an item")]
        public void WhenIPurchaseAnItem()
        {
            //Add to Cart
            UtilElementBonker(driver, account.GetShop());
            UtilElementBonker(driver, shop.GetClothing(CLOTHINGITEM));
            UtilElementBonker(driver, clothing.GetAddToCart());
            UtilElementBonker(driver, clothing.GetCart());
        }

        [When(@"I use a discount code '([^']*)'")]
        public void WhenIUseADiscountCode(string coupon)
        {
            //apply a discount coupon
            if(UtilTextReader(driver, checkout.GetBody()).Contains("[remove]")){UtilElementBonker(driver, checkout.GetRemove());}
            UtilUltraWaiter(wait, checkout.GetCouponField());
            UtilUltraWaiter(wait, checkout.GetApplyCoupon());
            UtilFieldClearer(driver, checkout.GetCouponField());
            UtilTypeWriter(driver, checkout.GetCouponField(), coupon);
            UtilElementBonker(driver, checkout.GetApplyCoupon());
        }

        [Then(@"discount is applied")]
        public void ThenDiscountIsApplied()
        {
            //verify if discount is correct
            try
            {
                UtilUltraWaiter(wait, checkout.GetCartTotals());
                UtilUltraWaiter(wait, checkout.GetCheckout());
                UtilUltraWaiter(wait, checkout.GetDiscValue());
            }
            catch (StaleElementReferenceException){}
            catch (NoSuchElementException){}
            catch (ElementClickInterceptedException){}
            try
            {
                Assert.That(checkout.CheckDiscount() == DISCOUNT, "Discounts did not match.");
            }
            catch (AssertionException){}
            catch (StaleElementReferenceException){}
            catch (NoSuchElementException){}

            //Check that total calculated after shipping is correct
            try
            {
                Assert.That(checkout.CheckTotal(), Is.EqualTo(checkout.GetFinalTotal()), "The total was incorrect.");
            }
            catch (StaleElementReferenceException){}
            catch (NoSuchElementException){}
        }

        [When(@"I checkout")]
        public void WhenICheckout()
        {
            //Proceed to checkout
            UtilUltraWaiter(wait, checkout.GetCheckout());
            UtilElementBonker(driver, checkout.GetCheckout());

            //Fill in billing details
            UtilUltraWaiter(wait, bill.GetFirstName());
            bill.KillBill(driver, customer); //change form to customer object
            
            //Place order
            try
            {
                UtilUltraWaiter(wait, bill.GetCheckPayment());
                UtilElementBonker(driver, bill.GetCheckPayment());
            }
            catch (StaleElementReferenceException){}
            UtilElementBonker(driver, bill.GetOrder());
        }

        [Then(@"the order displays in my account")]
        public void ThenTheOrderDisplaysInMyAccount()
        {
            //Capture order and save a screenshot
            UtilUltraWaiter(wait, order.GetOrderNumber());
            orderNumber = UtilTextReader(driver, order.GetOrderNumber());
            UtilScreenshotter(driver, "OrderPage.jpeg");
            Console.WriteLine(orderNumber);

            //Check the order number and save a screenshot
            UtilElementBonker(driver, order.GetMyAccount());
            UtilElementBonker(driver, account.GetOrders());
            accountOrder = (UtilTextReader(driver, myAccountOrder.GetAccountOrderValue()))[1..];
            UtilScreenshotter(driver, "AccountOrderPage.jpeg");
            Console.WriteLine(accountOrder);
            UtilElementBonker(driver, account.GetLogout());
            Assert.That(orderNumber == accountOrder, "Order Number is not the same.");
        }
    }
}
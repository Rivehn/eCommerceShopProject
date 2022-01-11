using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.Support
{
    public static class TestHelperClass
    {
        public static void UtilThreadSleeper(int seconds) //For all your most intense hatred of AJAX needs, just add how many seconds you want to KO the stupid machine for!
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void UtilUltraWaiter(WebDriverWait wait, By element) //Instantiate a unique wait object
        {
            wait.Until(drv => drv.FindElement(element).Displayed);
        }

        public static void UtilBasketClearer(IWebDriver driver) //MUST be at the basket page before calling this method
        {
            UtilThreadSleeper(5);//First wait for any leftover AJAX not accounted for.
            //Clear Coupon
            driver.FindElement(By.CssSelector(".woocommerce-remove-coupon")).Click();
            UtilThreadSleeper(5);
            //Clear Basket
            driver.FindElement(By.CssSelector(".remove")).Click(); //ONLY works with one item in basket I believe
        }

        public static void UtilElementBonker(IWebDriver driver, By element) //Bonks an element (clicks it)
        {
            driver.FindElement(element).Click();
        }

        public static string UtilTextReader(IWebDriver driver, By element)
        {
            return driver.FindElement(element).Text;
        }
        public static void UtilFieldClearer(IWebDriver driver, By element)
        {
            driver.FindElement(element).Clear();
        }
        public static void UtilTypeWriter(IWebDriver driver, By element, string value)
        {
            driver.FindElement(element).SendKeys(value);
        }

    }
}

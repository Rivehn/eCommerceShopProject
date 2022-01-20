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
        public static void UtilThreadSleeper(int seconds) //For all your intense hatred of AJAX needs, just add how long you want to KO your stupid machine for!
        {
            Thread.Sleep(seconds * 1000);
        }
        public static void UtilUltraWaiter(WebDriverWait wait, By element) //Explicit wait for an element to show
        {
            wait.Until(drv => drv.FindElement(element).Displayed);
        }
        public static void UtilBasketClearer(IWebDriver driver) //MUST be at the basket page before calling this method
        {
            UtilThreadSleeper(5);//wait for any leftover AJAX
            //Clear Coupon
            driver.FindElement(By.CssSelector(".woocommerce-remove-coupon")).Click();
            UtilThreadSleeper(5);
            //Clear Basket
            driver.FindElement(By.CssSelector(".remove")).Click(); //Only works with one item in basket
        }
        public static void UtilElementClicker(IWebDriver driver, By element) //Bonks an element (clicks it)
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
        public static void UtilScreenshotter(IWebDriver driver, string screenshotName) //filepath must be configured on different machines
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\PeterDeng\Pictures\" + screenshotName, ScreenshotImageFormat.Jpeg);
            Console.WriteLine(@"Screenshot has been saved to: C:\Users\PeterDeng\Pictures\" + screenshotName + ".Jpeg");
        }
        public static void UtilExtendedClicker(IWebDriver driver, By element, string expectedUrl)
        {
            int tries = 0;
            while(driver.Url != expectedUrl && tries <= 5)
            {
                tries++;
                try
                {
                    UtilElementClicker(driver, element);
                }
                catch (StaleElementReferenceException) { }
                catch (NoSuchElementException) { }
                catch (ElementClickInterceptedException) { }
                if(driver.Url == expectedUrl)
                {
                    Console.WriteLine("Click is successful");
                }
                else
                {
                    //Console.WriteLine("Attempt: " + tries + " unsuccessful.");
                }
            }
        }
    }
}

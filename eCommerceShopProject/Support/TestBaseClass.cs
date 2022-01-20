using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.Support
{
    [Binding]
    public class TestBaseClass
    {
        public static IWebDriver? driver;
        public static WebDriverWait? wait;
        public const int DISCOUNT = 15; // 100 = 100% ACTUAL DISCOUNT = 15
        public string? orderNumber; //Captured after checkout
        public string? accountOrder; //Captured in My accounts
        public const string CLOTHINGITEM = "firstItem";

        [BeforeTestRun]
        public static void Setup()
        {
            ChromeOptions options = new();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        [AfterTestRun]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}

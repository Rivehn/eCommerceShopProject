using eCommerceShopProject.ScenarioObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class BillPOM
    {
        By firstname = By.Id("billing_first_name");
        By lastname = By.Id("billing_last_name");
        By company = By.Id("billing_company");
        By addressOne = By.Id("billing_address_1");
        By addressTwo = By.Id("billing_address_2");
        By city = By.Id("billing_city");
        By state = By.Id("billing_state");
        By postcode = By.Id("billing_postcode");
        By phone = By.Id("billing_phone");
        By email = By.Id("billing_email");
        By checkPayment = By.CssSelector(".payment_method_cheque.wc_payment_method > label");
        By order = By.CssSelector("button#place_order");
        public void KillBill(IWebDriver driver, Customer customer) //Extra Killer Form Filler
        {
            //first name
            driver.FindElement(firstname).Clear();
            driver.FindElement(firstname).SendKeys(customer.GetFirstName());
            //last name
            driver.FindElement(lastname).Clear();
            driver.FindElement(lastname).SendKeys(customer.GetLastName());
            //company name
            driver.FindElement(company).Clear();
            driver.FindElement(company).SendKeys(customer.GetCompany());
            //street address
            driver.FindElement(addressOne).Clear();
            driver.FindElement(addressOne).SendKeys(customer.GetAddressOne());
            //apartment
            driver.FindElement(addressTwo).Clear();
            driver.FindElement(addressTwo).SendKeys(customer.GetAddressTwo());
            //town / city
            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys(customer.GetCity());
            //county
            driver.FindElement(state).Clear();
            driver.FindElement(state).SendKeys(customer.GetState());
            //postcode
            driver.FindElement(postcode).Clear();
            driver.FindElement(postcode).SendKeys(customer.GetPostCode());
            //phone
            driver.FindElement(phone).Clear();
            driver.FindElement(phone).SendKeys(customer.GetPhone());
            //email address
            driver.FindElement(email).Clear();
            driver.FindElement(email).SendKeys(customer.GetEmail());
        }
        public By GetCheckPayment(){return checkPayment;}
        public By GetOrder(){return order;}
        public By GetFirstName(){return firstname;}
    }


}

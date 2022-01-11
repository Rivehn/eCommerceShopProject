using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class OrderPOM
    {
        By orderNumber = By.CssSelector(".order > strong");
        By myAccount = By.LinkText("My account");
        public By GetOrderNumber(){return orderNumber;}
        public By GetMyAccount(){return myAccount;}
    }
}

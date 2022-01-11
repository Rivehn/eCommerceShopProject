using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class MyAccountPOM
    {
        By orders = By.LinkText("Orders");
        By shop = By.LinkText("Shop");
        By logout = By.CssSelector(".woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--customer-logout > a");
        public By GetOrders(){return orders;}
        public By GetShop(){return shop;}
        public By GetLogout(){return logout;}
    }
}

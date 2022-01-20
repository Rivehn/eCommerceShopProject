using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class MyAccountOrderPOM
    {
        By accountOrderValue = By.CssSelector("tr:nth-of-type(1) > .woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number > a");
        public By GetAccountOrderValue(){return accountOrderValue;}
    }
}
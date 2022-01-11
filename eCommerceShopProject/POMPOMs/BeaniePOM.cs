using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class BeaniePOM
    {
        By addToCart = By.CssSelector("button[name='add-to-cart']");
        By cart = By.LinkText("Cart");
        public By GetAddToCart(){return addToCart;}
        public By GetCart(){return cart;}
    }
}

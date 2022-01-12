using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class ShopPOM
    {
        By beanie = By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/beanie/']");
        By belt = By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/belt/']");
        By cap = By.XPath("//main[@id='main']/ul//a[@href='https://www.edgewordstraining.co.uk/demo-site/product/cap/']");
        
        By firstItem = By.CssSelector("#main > ul.columns-3.products > li:first-child"); //first item in the shop
        public By? GetClothing(string itemIndex)
        {
            switch (itemIndex)
            {
                default:
                    throw new Exception("Item not recognised");
                case "beanie":
                    return beanie;
                case "belt":
                    return belt;
                case "cap":
                    return cap;
                case "firstItem":
                    return firstItem;
            }
        }
    }
}

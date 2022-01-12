using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class CheckoutPOM
    {
        IWebDriver driver;
        public CheckoutPOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        By total = By.CssSelector("#post-5 > div > div > form > table > tbody > tr.woocommerce-cart-form__cart-item.cart_item > td.product-subtotal > span");
        By couponField = By.Id("coupon_code");
        By applyCoupon = By.CssSelector("button[name='apply_coupon']");
        By body = By.TagName("body");
        //IWebElement Checkout => driver.FindElement(By.CssSelector(".alt.button.checkout-button.wc-forward"));
        By checkoutButton = By.LinkText("Proceed to checkout");
        By cartTotals = By.CssSelector("#post-5 > div > div > div > div");
        By remove = By.CssSelector(".woocommerce-remove-coupon");
        By discValue = By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount");
        decimal totalValue => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal actValue => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal subTotal => System.Convert.ToDecimal
               ((driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal discountAmount => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal shippingCost => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal finalTotal => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).Text)[1..]);
        public decimal CheckDiscount(){return ((actValue / totalValue) * 100);}
        public decimal CheckTotal(){return (subTotal + (-discountAmount) + shippingCost);}
        public decimal GetFinalTotal(){return finalTotal;}
        public By GetRemove(){return remove;}
        public By GetDiscValue(){return discValue;}
        public By GetCartTotals(){return cartTotals;}
        public By GetTotal(){return total;}
        public By GetCouponField(){return couponField;}
        public By GetApplyCoupon(){return applyCoupon;}
        public By GetBody(){return body;}
        public By GetCheckout(){return checkoutButton;}
    }
}

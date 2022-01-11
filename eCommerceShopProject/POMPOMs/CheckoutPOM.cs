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
        By Total = By.CssSelector("#post-5 > div > div > form > table > tbody > tr.woocommerce-cart-form__cart-item.cart_item > td.product-subtotal > span");
        By CouponField = By.Id("coupon_code");
        By ApplyCoupon = By.CssSelector("button[name='apply_coupon']");
        By Body = By.TagName("body");
        //IWebElement Checkout => driver.FindElement(By.CssSelector(".alt.button.checkout-button.wc-forward"));
        By Checkout = By.LinkText("Proceed to checkout");
        By CartTotals = By.CssSelector("#post-5 > div > div > div > div");
        By Remove = By.CssSelector(".woocommerce-remove-coupon");
        By DiscValue = By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount");
        decimal TotalValue => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal ActValue => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal SubTotal => System.Convert.ToDecimal
               ((driver.FindElement(By.CssSelector(".cart-subtotal > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal DiscountAmount => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal ShippingCost => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector(".shipping > td > .amount.woocommerce-Price-amount")).Text)[1..]);
        decimal FinalTotal => System.Convert.ToDecimal
            ((driver.FindElement(By.CssSelector("strong > .amount.woocommerce-Price-amount")).Text)[1..]);
        public decimal CheckDiscount(){return ((ActValue / TotalValue) * 100);}
        public decimal CheckTotal(){return (SubTotal + (-DiscountAmount) + ShippingCost);}
        public decimal GetFinalTotal(){return FinalTotal;}
        public By GetRemove(){return Remove;}
        public By GetDiscValue(){return DiscValue;}
        public By GetCartTotals(){return CartTotals;}
        public By GetTotal(){return Total;}
        public By GetCouponField(){return CouponField;}
        public By GetApplyCoupon(){return ApplyCoupon;}
        public By GetBody(){return Body;}
        public By GetCheckout(){return Checkout;}
    }
}

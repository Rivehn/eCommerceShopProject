using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceShopProject.POMPOMs
{
    public class LoginPOM
    {
        By usernameField = By.Id("username");
        By passwordField = By.Id("password");
        By submitButton = By.CssSelector("button[name='login']");
        By bottomThing = By.LinkText("Dismiss"); //Bottom banner
        public By GetSubmit(){return submitButton;}
        public By GetUsernameField(){return usernameField;}
        public By GetPasswordField(){return passwordField;}
        public By GetBottomThing() { return bottomThing;}
    }
}

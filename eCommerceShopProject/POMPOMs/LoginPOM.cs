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
        By UsernameField = By.Id("username");
        By PasswordField = By.Id("password");
        By SubmitButton = By.CssSelector("button[name='login']");
        public By GetSubmit(){return SubmitButton;}
        public By GetUsernameField(){return UsernameField;}
        public By GetPasswordField(){return PasswordField;}
    }
}

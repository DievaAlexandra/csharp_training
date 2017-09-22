using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{

    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        //вход в систему
        public void Login(AccountData account)
        {
            if (IsLoggetIn())
            {
                Logout();
            }
           
            Type(By.Id("username"), account.Username);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        //выход из системы
        public void Logout()
        {
            if (IsLoggetIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        //определяем выполнен ли вход в систему
        public bool IsLoggetIn()
        {
            return IsElementPresent(By.CssSelector("span.smaller-75"));
        }
    }
}

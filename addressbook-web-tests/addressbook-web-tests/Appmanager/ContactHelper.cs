using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
      
        public ContactHelper(IWebDriver driver): base(driver)
        {
        }
        public void FillContactForm(UserData user)
        {
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            Driver.FindElement(By.Name("middlename")).Clear();
            Driver.FindElement(By.Name("middlename")).SendKeys(user.Middlename);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(user.LastName);
        }
        public void GoToCreateContactPage()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
        }
        public void SubmitContactCreation()
        {
            Driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
    }
}

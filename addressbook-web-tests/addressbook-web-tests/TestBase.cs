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
   public class TestBase
    {
        protected IWebDriver Driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions
            {
                BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe",
                UseLegacyImplementation = true
            };
            Driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();

        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void GoToHomePage()
        {
            Driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        protected void Login(AccountData account)
        {
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(account.Username);
            Driver.FindElement(By.Name("pass")).Clear();
            Driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        protected void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void Logout()
        {
            Driver.FindElement(By.LinkText("Logout")).Click();
        }

        protected void InitGroupCreation()
        {
            Driver.FindElement(By.Name("new")).Click();
        }
        protected void ReturnToGroupPage()
        {
            Driver.FindElement(By.LinkText("group page")).Click();
        }
        protected void FillGroupForm(GroupData group)
        {
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected  void SubmitGroupCreation()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }
        protected void RemoveGroup()
        {
            Driver.FindElement(By.Name("delete")).Click();
        }
        protected void SelectGroup(int index)
        {
            Driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
        protected void FillContactForm(UserData user)
        {
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            Driver.FindElement(By.Name("middlename")).Clear();
            Driver.FindElement(By.Name("middlename")).SendKeys(user.Middlename);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(user.LastName);
        }
        protected void GoToCreateContactPage()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
        }
        protected void SubmitContactCreation()
        {
            Driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }
        protected bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

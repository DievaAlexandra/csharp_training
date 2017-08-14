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
      
        public ContactHelper(ApplicationManager manager): base(manager)
        {
        }
        public ContactHelper Create(UserData contact)
        {
            manager.Navigator.GoToHomePage();

            GoToCreateContactPage();
            FillContactForm(new UserData("alisa", "grozny", "durachok"));
            SubmitContactCreation();
          return this;
        }
        public ContactHelper FillContactForm(UserData user)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(user.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.LastName);
            return this;
        }

        public ContactHelper Modify(int v, UserData user)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactModification();
            FillContactForm(user);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int i)
        {
            manager.Navigator.GoToHomePage();

            SelectContact(i);
            DeleteContact();
            SubmitDeleteContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SubmitDeleteContact()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper  DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper GoToCreateContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[1]")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            return this;
        }
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            return this;
        }

   
    }
}

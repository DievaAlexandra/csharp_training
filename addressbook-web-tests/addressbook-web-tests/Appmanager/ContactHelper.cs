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
            FillContactForm(contact);
            SubmitContactCreation();
          return this;
        }
        public ContactHelper FillContactForm(UserData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("lastname"), user.LastName);
            return this;
        }

        public ContactHelper Modify(int v, UserData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(v);
            InitContactModification();
            FillContactForm(contact);
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
            contactCache = null;
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (v+1) + "]")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public bool ThereAreContacts()
        {
            return IsElementPresent(By.CssSelector("img[alt=\"Details\"]"));
        }

        private List<UserData> contactCache = null;


        public List<UserData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<UserData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(.//*[@id='maintable']/tbody/tr)"));

                foreach (IWebElement row in elements)
                {

                    ICollection<IWebElement>  cells = row.FindElements(By.TagName("td"));
                    if (cells.Count > 2)
                    {
                        contactCache.Add(new UserData(cells.ElementAt(1).Text, cells.ElementAt(2).Text));
                    }
                    
                }

            }
            return contactCache;
        }
    }
}

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
            FillContactForm(new UserData("alisa", "grozny"));
            SubmitContactCreation();
          return this;
        }
        public ContactHelper FillContactForm(UserData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("lastname"), user.LastName);
            return this;
        }

        public ContactHelper Modify(int v, UserData user)
        {
            manager.Navigator.GoToHomePage(); //внутри проверка находимся ли мы на стартовой странице. если нет, то отрабатывает метод gotohomepage если да, то ничего не делаем
            SelectContact(v);//находим первый элемент с name = selected выбираем его
            InitContactModification();//для этого элемента ищем кнопку edit и жмакаем ее
            FillContactForm(user);//заполняем форму 
            SubmitContactModification();//подтверждаем изменение
            manager.Navigator.GoToHomePage();//возвращаемся на стартовую страницу
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
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(.//*[@id='maintable']/tbody/tr/td[2])"));

                foreach (IWebElement element in elements)
                {
                    
                    contactCache.Add(new UserData(element.Text, element.Text));
                }

            }
           return new List<UserData>(contactCache);
        }
    }
}

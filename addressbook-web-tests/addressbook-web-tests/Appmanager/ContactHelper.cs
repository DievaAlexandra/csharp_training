using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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

        //создание 
        public ContactHelper Create(UserData contact)
        {
            manager.Navigator.GoToHomePage();
            GoToCreateContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        //изменение 
        public ContactHelper Modify(int i, UserData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(i);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        //изменение по id в БД
        public ContactHelper Modify(UserData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contact.Id);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        //удаление по индексу в UI
        public ContactHelper Remove(int i)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(i);
            DeleteContact();
            SubmitDeleteContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        //удаление по Id в БД
      public ContactHelper Remove(UserData contact)
        {
           manager.Navigator.GoToHomePage();
           SelectContact(contact.Id);
           DeleteContact();
           SubmitDeleteContact();
           manager.Navigator.GoToHomePage();
           return this;
        }

        //проверка наличия элементов в списке
        public bool ThereAreContacts()
        {
            return IsElementPresent(By.CssSelector("img[alt=\"Details\"]"));
        }

        //получение кол-ва элементов в списке
        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("(.//*[@id='maintable']/tbody/tr/td[8]/a/img)")).Count;
        }

        //получение кол-ва результата поиска
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.Id("search_count")).Text;
            return Int32.Parse(text);
        }

        //выбор элемента из списка UI
        public ContactHelper SelectContact(int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (i + 1) + "]")).Click();
            return this;
        }

        //переход на страницу создания
        public ContactHelper GoToCreateContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        //заполнение формы 
        public ContactHelper FillContactForm(UserData user)
        {
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("lastname"), user.LastName);
            return this;
        }
       
        //подтверждение действия "Создать"
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            contactCache = null;
            return this;
        }

        //подтверждение действия "Изменить"
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            contactCache = null;
            return this;
        }

        //выбор действия "Удалить"
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        //подтверждение действия "Удалить"
        public ContactHelper SubmitDeleteContact()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        //получение списка 
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
        
        //переход на детальную страницу
        public ContactHelper GoToDetailsPage(int i)
        {
            driver.FindElements(By.CssSelector("img[alt=\"Details\"]"))[i].Click();
            return this;
        }

        //выбор элемента из списка DB
        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        //переход на страницу редактирования БД
        public ContactHelper InitContactModification(String id)
        {
            driver.FindElements(By.CssSelector("a[href*='id=" + id + "'] > img[alt=\"Edit\"]"))[0].Click();
            return this;
        }

        //переход на страницу редактирования
        public ContactHelper InitContactModification(int i)
        {
            driver.FindElements(By.CssSelector("img[alt=\"Edit\"]"))[i].Click();
            return this;
        }
        //получение данных из таблицы
        public UserData GetContactInformationFromTable(int i)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[i].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new UserData(lastName, firstName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        //получение данных из детальной страницы 
        public string GetContactInformationFromDetails(int i)
        {
            manager.Navigator.GoToHomePage();
            GoToDetailsPage(i);
            string detinfo = driver.FindElement(By.CssSelector("div#content")).Text;

            return detinfo;
        }

        //получение данных из страницы редактирования
        public UserData GetContactInformationFromEditForm(int i) //получение данных контакта из формы редактирования
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(i);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new UserData(lastName, firstName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }

        //добавление контакта в группу 
        public void AddContactToGroup(UserData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

      

        public void CommitAddingContactToGroup()
        {
           driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(groupName);
        }

        public void ClearGroupFilter()
        {
          new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}

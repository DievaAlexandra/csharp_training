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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager): base(manager)
        {
        }

        //создание
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        //изменение
        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        //изменение БД
        public GroupHelper Modify(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        //удаление по индексу Ui
        public GroupHelper Remove(int i)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(i);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        //удаление по индексу из БД
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        //возврат на страницу списка
        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        //заполнение формы
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        //выбор действия "Создать"
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        //подтверждение действия "Создать"
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        //выбор элемента по индексу из UI
        public GroupHelper SelectGroup(int index)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        //выбор элемента по id из БД
        public GroupHelper SelectGroup(String id)
        {

            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        //выбор действия "Изменить"
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        //выбор действия "Изменить" БД
        public GroupHelper InitGroupModification(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='edit' and @value='" + id + "'])")).Click();
            return this;
        }

        //подтверждение действия "Изменить"
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        
        //проверка наличия элементов в списке
        public bool ThereAreGroup()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])"));
        }

        private List<GroupData> groupCache = null;

        //получение списка элементов
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); 
                foreach (IWebElement element in elements)

                    groupCache.Add(new GroupData(null)
                        {Id = element.FindElement(By.TagName("input")).GetAttribute("value")});
            }

            string allGroupsNames = driver.FindElement(By.CssSelector("div#content form")).Text;
            string[] parts = allGroupsNames.Split('\n');
            int shift = groupCache.Count - parts.Length;

            for (int i = 0; i < groupCache.Count; i++)
            {
                if (i < shift)
                {
                    groupCache[i].Name = "";
                }
                else
                {
                    groupCache[i].Name = parts[i - shift].Trim();
                }
               
            }

            return new List<GroupData>(groupCache);
        }

        //получение кол-ва элементов в списке
        public int GetGroupCount()
        {
            return  driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}

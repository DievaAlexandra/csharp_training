﻿using System;
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
       
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }
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
        
        public GroupHelper Remove(int i)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(i);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }
        
        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
         }

  
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
          
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool ThereAreGroup()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[1]'])"));
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>(); //создаем новый элемент списка
            manager.Navigator.GoToGroupsPage();//переходим на страницу групп
            ICollection <IWebElement> elements =  driver.FindElements(By.CssSelector("span.group"));//находим все элементы имеющие тэг SPAN и класс GROUP
            foreach (IWebElement element in elements)//цикл для обработки всех элементов в списке элементы
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
 }

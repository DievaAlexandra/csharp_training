using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        //переход на домашнюю страницу
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "my_view_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "my_view_page.php");
        }

        //переход на страницу проектов
        public void GoToProjectPage()
        {
            if (driver.Url == baseURL + "manage_proj_page.php")
            {
                return;
            }
            driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/span")).Click();
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }
    }
}

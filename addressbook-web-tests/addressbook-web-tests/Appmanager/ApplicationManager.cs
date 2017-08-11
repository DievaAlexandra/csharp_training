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
    public class ApplicationManager
    {
        protected IWebDriver Driver;
        protected string BaseUrl;

        protected LoginHelper Loginhelper;
        protected NavigationHelper navigator;
        protected GroupHelper GroupHelper;
        protected ContactHelper ContactHelper;

        
        public ApplicationManager(IWebDriver driver)
        {
            Driver = driver;
            Loginhelper = new LoginHelper(Driver);
            navigator = new NavigationHelper(Driver, "https://localhost/");
            GroupHelper = new GroupHelper(Driver);
            ContactHelper = new ContactHelper(Driver);
        }

        public void Stop()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return Loginhelper;
            }

        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return ContactHelper;
            }
        }

        public GroupHelper Groups
        {
            get { return GroupHelper; }
        }

    }
}

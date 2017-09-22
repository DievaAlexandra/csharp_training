﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        private static ThreadLocal<ApplicationManager> app  = new ThreadLocal<ApplicationManager>();


        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions

            {
                BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe",
                UseLegacyImplementation = true
            };
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
        }

        public FtpHelper Ftp { get; set; }

        public RegistrationHelper Registration { get; set; }

        ~ApplicationManager()

        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
               newInstance.driver.Url = "http://localhost/mantisbt-2.6.0/login_page.php";
                app.Value = newInstance;
          
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}

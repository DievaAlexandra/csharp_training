using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://dev.tripandfly.local";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void SearchTickets()
        {
            driver.Navigate().GoToUrl(baseURL + "/B2b/Login");
            driver.FindElement(By.Name("Login")).Clear();
            driver.FindElement(By.Name("Login")).SendKeys("test_1");
            driver.FindElement(By.Name("Password")).Clear();
            driver.FindElement(By.Name("Password")).SendKeys("МойПароль123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();


            driver.FindElement(By.Name("FromName")).SendKeys("grreh");
            
            driver.FindElement(By.ClassName("ToName")).SendKeys("Санкт-Петербург");
            driver.FindElement(By.Name("DepartureDate")).Clear();
            driver.FindElement(By.Name("DepartureDate")).SendKeys("15.09.2017");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
       
    }
}

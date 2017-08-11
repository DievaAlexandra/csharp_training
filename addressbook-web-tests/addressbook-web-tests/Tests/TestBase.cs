using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;


namespace WebAddressbookTests
{
   public class TestBase
    {
         
        protected ApplicationManager App;

        [SetUp]
        public void SetupTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = true;
            var driver = new FirefoxDriver(options);
            App = new ApplicationManager(driver);


         }

        [TearDown]
        public void TeardownTest()
        {
           App.Stop();
        }
    }
}

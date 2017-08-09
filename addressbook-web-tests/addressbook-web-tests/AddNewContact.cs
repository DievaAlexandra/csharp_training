using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContact : TestBase
    {
      [Test]
        public void AddNewContactTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToCreateContactPage();
            FillContactForm(new UserData("sasha", "dieva", "bu"));
            SubmitContactCreation();
            GoToHomePage();
            Logout();
        }
    }
}

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
            App.Navigator.GoToHomePage();
            App.Auth.Login(new AccountData("admin", "secret"));
            App.Contacts.GoToCreateContactPage();
            App.Contacts.FillContactForm(new UserData("ivan", "grozny", "durachok"));
            App.Contacts.SubmitContactCreation();
            App.Navigator.GoToHomePage();
            App.Auth.Logout();
        }
    }
}

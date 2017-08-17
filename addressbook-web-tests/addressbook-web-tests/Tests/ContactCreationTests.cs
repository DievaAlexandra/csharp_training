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
    public class AddNewContact : AuthTestBase
    {
      [Test]
        public void AddNewContactTest()
        {
            UserData contact = new UserData("alisa", "grozny", "durachok");
            app.Contacts.Create(contact);
        }
    }
}

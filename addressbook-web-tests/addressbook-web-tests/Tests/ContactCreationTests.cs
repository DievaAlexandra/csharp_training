using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    public class ContactCreationTests : AuthTestBase
    {
      [Test]
        public void ContactCreationTest()
        {
            UserData contact = new UserData("vgergre", "ergergerg");

            List<UserData> oldContactList = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<UserData> newcContactList = app.Contacts.GetContactList();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newcContactList.Sort();
            Assert.AreEqual(oldContactList, newcContactList);
            
        }

        [Test]

        public void ContactCreationTestInvalid()
        {
            UserData contact = new UserData("сэ'", "hk'");

            List<UserData> oldContactList = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<UserData> newcContactList = app.Contacts.GetContactList();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newcContactList.Sort();
            Assert.AreEqual(oldContactList, newcContactList);

        }
    }
}

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

        public static IEnumerable<UserData> RandomContactDataProvider()
        {
            List<UserData> contacts = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new UserData(GenerateRandomString(20), GenerateRandomString(20)));
            }

            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(UserData contact)
        {
           

            List<UserData> oldContactList = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContactList.Count + 1, app.Contacts.GetContactCount());

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

            Assert.AreEqual(oldContactList.Count + 1, app.Contacts.GetContactCount());

            List<UserData> newcContactList = app.Contacts.GetContactList();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newcContactList.Sort();
            Assert.AreEqual(oldContactList, newcContactList);

        }
    }
}

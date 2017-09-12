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
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

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

        public static IEnumerable<UserData> ContactDataFromXmlFile()
        {
            List<UserData> contacts = new List<UserData>();

            return (List<UserData>)new XmlSerializer(typeof(List<UserData>))
                .Deserialize( new StreamReader(TestContext.CurrentContext.TestDirectory + @"\contacts.xml"));
        }

        public static IEnumerable<UserData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(File.ReadAllText(TestContext
                                                                                       .CurrentContext.TestDirectory + @"\contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(UserData contact)
        {


            List<UserData> oldContactList = UserData.GetAll();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContactList.Count + 1, app.Contacts.GetContactCount());

            List<UserData> newcContactList = UserData.GetAll();
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

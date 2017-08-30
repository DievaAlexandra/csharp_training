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
    [TestFixture]
    public class ContactInformationTests: AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
           UserData fromTable = app.Contacts.GetContactInformationFromTable(0);
           UserData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

          
            Assert.AreEqual(fromTable,fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromEditForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
        }

        [Test]

        public void TestDetailsInformation()
        {
            UserData fromDetailsForm = app.Contacts.GetContactInformationFromDetails(0);
            UserData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);


            Assert.AreEqual(fromDetailsForm, fromEditForm);
         
        }


    }
}

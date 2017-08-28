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
           UserData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //проверки какие то
            Assert.AreEqual(fromTable,fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

      
    }
}

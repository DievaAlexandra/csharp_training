using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            
            
            string fromDetailsForm = app.Contacts.GetContactInformationFromDetails(0);//метод получения инфы из детальной
            UserData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);
            string glue = String.Format(
                "{0} {1}\r\n{2}\r\n\r\nH: {3}\r\nM: {4}\r\nW: {5}\r\n\r\n{6}\r\n{7}\r\n{8}",
                fromEditForm.Firstname,
                fromEditForm.LastName,
                fromEditForm.Address,
                fromEditForm.HomePhone,
                fromEditForm.MobilePhone,
                fromEditForm.WorkPhone,
                fromEditForm.Email,
                fromEditForm.Email2,
                fromEditForm.Email3
            );

            Assert.AreEqual(fromDetailsForm, glue);

        }

    }
}

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

            string glue = (string.IsNullOrEmpty(fromEditForm.Firstname) ? "" : fromEditForm.Firstname + " ") +
                          (string.IsNullOrEmpty(fromEditForm.LastName) ? "" : fromEditForm.LastName + "\r\n")  +
                          (string.IsNullOrEmpty(fromEditForm.Address) ? "" : fromEditForm.Address + "\r\n") +
                          (string.IsNullOrEmpty(fromEditForm.HomePhone) ? "" : "\r\n" + "H: " + fromEditForm.HomePhone) +
                          (string.IsNullOrEmpty(fromEditForm.MobilePhone) ? "" : "\r\n" + "M: " + fromEditForm.MobilePhone) +
                          (string.IsNullOrEmpty(fromEditForm.WorkPhone) ? "" : "\r\n" + "W: " + fromEditForm.WorkPhone) +
                          (string.IsNullOrEmpty(fromEditForm.Email) ? "" : "\r\n" + "\r\n" + fromEditForm.Email) +
                          (string.IsNullOrEmpty(fromEditForm.Email2) ? "" : "\r\n" + fromEditForm.Email2) +
                          (string.IsNullOrEmpty(fromEditForm.Email3) ? "" : "\r\n" + fromEditForm.Email3);


      

            Assert.AreEqual(fromDetailsForm, glue);

        }

    }
}

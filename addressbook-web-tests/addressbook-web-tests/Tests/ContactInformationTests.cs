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

            var fio = ((string.IsNullOrEmpty(fromEditForm.Firstname) ? "" : fromEditForm.Firstname) + " " +
                       (string.IsNullOrEmpty(fromEditForm.LastName) ? "" : fromEditForm.LastName)).Trim();

            var address = string.IsNullOrEmpty(fromEditForm.Address) ? "" : $"\r\n{fromEditForm.Address}";

          

            var hphone = string.IsNullOrEmpty(fromEditForm.HomePhone) ? "" : $"H: {fromEditForm.HomePhone}";
            var mphone = string.IsNullOrEmpty(fromEditForm.MobilePhone) ? "" : $"\r\nM: {fromEditForm.MobilePhone}";
            var wphone = string.IsNullOrEmpty(fromEditForm.WorkPhone) ? "" : $"\r\nW: {fromEditForm.WorkPhone}";

            var phones = string.IsNullOrEmpty($"{hphone}{mphone}{wphone}") ? "" : $"{hphone}{mphone}{wphone}\r\n\r\n";

            var email = string.IsNullOrEmpty(fromEditForm.Email) ? "" : fromEditForm.Email;
            var email2 = string.IsNullOrEmpty(fromEditForm.Email2) ? "" : $"\r\n{fromEditForm.Email2}";
            var email3 = string.IsNullOrEmpty(fromEditForm.Email3) ? "" : $"\r\n{fromEditForm.Email3}";


            
            var glue = ($"{fio}{address}\r\n\r\n" +
                        $"{phones}" +
                        $"{email}{email2}{email3}").Trim();

            Assert.AreEqual(fromDetailsForm, glue);

        }

    }
}

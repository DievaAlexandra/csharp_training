using System;
using System.Collections.Generic;
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
            UserData contact = new UserData("alisa", "grozny");

            List<UserData> oldContactList = app.Contacts.GetContactList(); //получаем старый список контактов

            app.Contacts.Create(contact); //добавляем новый контакт

            List<UserData> newcContactList = app.Contacts.GetContactList();//получаем новый список контактов 
            oldContactList.Add(contact);
            oldContactList.Sort();//сортируем старый список
            newcContactList.Sort();//сортируем новый список
            Assert.AreEqual(oldContactList, newcContactList);//сверяем два списка
            
        }
   }
}

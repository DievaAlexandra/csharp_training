using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.ThereAreContacts())
            {
                app.Contacts.Create(new UserData("небыло", "контактов"));
            }
           
            List<UserData> oldContactList = UserData.GetAll();
            UserData toBeRemoved = oldContactList[0];

            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContactList.Count - 1, app.Contacts.GetContactCount());

            List<UserData> newContactList = UserData.GetAll();

            oldContactList.RemoveAt(0);
            Assert.AreEqual(oldContactList,newContactList);

            foreach (UserData contact in newContactList)
            {
               Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}

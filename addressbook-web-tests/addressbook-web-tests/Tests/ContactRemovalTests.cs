using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.ThereAreContacts())
            {
                app.Contacts.Create(new UserData("небыло", "контактов"));
            }
            List<UserData> oldContactList = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            Assert.AreEqual(oldContactList.Count - 1, app.Contacts.GetContactCount());

            List<UserData> newContactList = app.Contacts.GetContactList();

            oldContactList.RemoveAt(0);
            Assert.AreEqual(oldContactList,newContactList);

        }
    }
}

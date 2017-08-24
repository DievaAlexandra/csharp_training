using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (! app.Contacts.ThereAreContacts())
            {
                app.Contacts.Create(new UserData("небыло","контактов"));
            }

            UserData user = new UserData("еслитывидишьэтозначитконтактобновился","gazprom");

            List<UserData> oldContactList = app.Contacts.GetContactList();

            app.Contacts.Modify(0, user);

            Assert.AreEqual(oldContactList.Count, app.Contacts.GetContactCount());

            List<UserData> newcContactList = app.Contacts.GetContactList();
            oldContactList[1].Firstname = user.Firstname;
            oldContactList[1].LastName = user.LastName;
            oldContactList.Sort();
            newcContactList.Sort();
            Assert.AreEqual(oldContactList, newcContactList);
        }
    }
}

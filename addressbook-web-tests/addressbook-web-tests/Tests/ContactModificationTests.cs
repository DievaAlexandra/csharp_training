using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (! app.Contacts.ThereAreContacts())
            {
                app.Contacts.Create(new UserData("небыло","контактов"));
            }

            UserData user = new UserData("еслитывидишьэтозначитконтактобновился","gazprom");

            List<UserData> oldContactList = UserData.GetAll();
            UserData toBeChanged = oldContactList[0];

            app.Contacts.Modify(toBeChanged);

            Assert.AreEqual(oldContactList.Count, app.Contacts.GetContactCount());

            List<UserData> newcContactList = UserData.GetAll();
            toBeChanged.Firstname = user.Firstname;
            toBeChanged.LastName = user.LastName;
            oldContactList.Sort();
            newcContactList.Sort();
            Assert.AreEqual(oldContactList, newcContactList);
        }
    }
}

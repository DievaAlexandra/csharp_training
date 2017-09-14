using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class RemovalContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovalContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<UserData> oldlist = group.GetContacts();
            UserData user = new UserData("контактоввгруппенет'", "создаем'");


            { if (oldlist.Count < 1)
            {
                app.Contacts.AddContactToGroup(group.GetContacts()[1], group);
            }
            else
            {
            }}

            UserData contact = oldlist.First();
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<UserData> newlist = group.GetContacts();
            oldlist.Remove(contact);
            oldlist.Sort();
            newlist.Sort();
            Assert.AreEqual(oldlist, newlist);

        }
    }
}

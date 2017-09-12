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
            List<UserData> oldList = group.GetContacts();
            UserData contact = UserData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

        }
    }
}

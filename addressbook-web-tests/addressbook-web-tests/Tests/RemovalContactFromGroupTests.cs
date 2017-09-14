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

            int groupcount = GroupData.GetAll().Count;
            if (groupcount == 0)
            {
                app.Groups.Create(new GroupData("группакоторая"));
            }
            
            
            GroupData groups = GroupData.GetAll()[0];
            List<UserData> oldlist = groups.GetContacts();
            if (oldlist.Count ==0)
            {
                UserData user = new UserData("test", "test");
                app.Contacts.AddContactToGroup(user, groups);
                oldlist.Add(user);
            }

            
            UserData contact = oldlist.First();
            //app.Contacts.RemoveContactFromGroup(contact, group);
           // List<UserData> newlist = group.GetContacts();
            oldlist.Remove(contact);
            oldlist.Sort();
            //newlist.Sort();
           // Assert.AreEqual(oldlist, newlist);

        }
    }
}

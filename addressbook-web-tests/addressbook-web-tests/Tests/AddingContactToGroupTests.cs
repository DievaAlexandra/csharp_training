using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            int groupcount = GroupData.GetAll().Count;
            if (groupcount == 0)
            {
                app.Groups.Create(new GroupData("группапервая"));
            }
           

         
            GroupData group = GroupData.GetAll()[0];
            List<UserData> oldList = group.GetContacts();
            UserData contact =  UserData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<UserData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

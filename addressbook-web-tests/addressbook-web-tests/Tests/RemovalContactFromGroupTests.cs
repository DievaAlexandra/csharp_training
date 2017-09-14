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
                app.Groups.Create(new GroupData("группапервая"));
            }
            
            GroupData groups = GroupData.GetAll()[0];// берем первую группу из списка групп
            List<UserData> oldlist = groups.GetContacts();//берем все контакты из этой первой группы
            if (oldlist.Count ==0)//смотрим кол-во контактов. еси 0, то
            {
                UserData user = new UserData("test", "test");
                app.Contacts.Create(user);
                app.Contacts.AddContactToGroup(user, groups);//добавляем созданный контакт в первую группу
               
            }

            
            UserData contact = oldlist[0];
            app.Contacts.RemoveContactFromGroup(contact, groups);
            List<UserData> newlist = groups.GetContacts();
        
            Assert.AreEqual(oldlist.Count-1,newlist.Count);//сравниваем кол-во элементов в старом и новом списке
        }
    }
}

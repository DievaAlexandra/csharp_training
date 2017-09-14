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
                
                UserData user = UserData.GetAll()[0];
                app.Contacts.AddContactToGroup(user, groups);//добавляем созданный контакт в первую группу
               
            }

            List<UserData> groupsafteradd = groups.GetContacts();//берем снова все контакты группы
            UserData contact = groupsafteradd[0];//контакт это первый элемент из обновленной группы
            app.Contacts.RemoveContactFromGroup(contact, groups);//удаление ииз группы
            List<UserData> newlist = groups.GetContacts();//
        
            Assert.AreEqual(groupsafteradd.Count-1,newlist.Count);//сравниваем кол-во элементов в старом и новом списке
        }
    }
}

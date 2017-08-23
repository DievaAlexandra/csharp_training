using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
    
        [Test]
        public void GroupRemovalTest()
        {
           if (!app.Groups.ThereAreGroup()) //Если групп нет в списке значит создаем группу
                app.Groups.Create(new GroupData("перваягруппа"));

            List<GroupData> oldGroups = app.Groups.GetGroupList();//смотрим список групп старый


            app.Groups.Remove(0); //удаляем группу

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList(); //смотрим список групп новый

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups); //сравниваем список групп старый и новый

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase 
    {
        [Test]
        
        public void GroupModificationTest()
        {
            if (! app.Groups.ThereAreGroup())
            {
               app.Groups.Create(new GroupData("группакоторая"));
            }

            GroupData newData = new GroupData("изменение");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeChanged = oldGroups[0];

            app.Groups.Modify(toBeChanged);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            toBeChanged.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeChanged.Id)
                {
                    Assert.AreEqual(group.Name, toBeChanged.Name );
                }
            }
        }
    }
}

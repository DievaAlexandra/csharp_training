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

            
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeChanged = oldGroups[1];

            GroupData newData = new GroupData("мпукпкп");
            newData.Header = toBeChanged.Header;
            newData.Footer = toBeChanged.Footer;
            newData.Id = toBeChanged.Id;

            app.Groups.Modify(newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            toBeChanged.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

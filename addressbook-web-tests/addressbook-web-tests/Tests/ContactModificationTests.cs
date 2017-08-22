using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (! app.Contacts.ThereAreContacts())
            {
                app.Contacts.Create(new UserData("небыло","контактов"));
            }
           UserData user = new UserData("еслитывидишьэтозначитконтактобновился","gazprom");
           app.Contacts.Modify(0, user);
        }
    }
}

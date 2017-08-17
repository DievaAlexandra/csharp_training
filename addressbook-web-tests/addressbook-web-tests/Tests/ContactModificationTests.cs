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

            UserData user = new UserData("еслитывидишьэтозначитконтактобновился","gazprom","bank");
            app.Contacts.Modify(1, user);
        }
    }
}

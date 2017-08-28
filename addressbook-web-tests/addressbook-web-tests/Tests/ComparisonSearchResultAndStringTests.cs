using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class SearchTests: AuthTestBase
    {
        [Test]
        public void ComparisonSearchResultAndStringTest()
        {
            int fromsearch = app.Contacts.GetNumberOfSearchResults();
            int fromtablestring = app.Contacts.GetContactCount();

            Assert.AreEqual(fromsearch, fromtablestring);
        }

  
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        
        public void GroupModificationTest()
        {
            if (! app.Groups.ThereAreGroup())
            {
                app.Groups.Create(new GroupData("группакоторая"));
            }
            GroupData newData = new GroupData("tadaaaaaaam");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }
    }
}

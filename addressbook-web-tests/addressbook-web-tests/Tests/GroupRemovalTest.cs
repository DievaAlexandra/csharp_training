using System;
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
    public class GroupRemovalTests : TestBase
    {
    
        [Test]
        public void GroupRemovalTest()
        {
            App.Navigator.GoToHomePage();
            App.Auth.Login(new AccountData("admin","secret"));
            App.Navigator.GoToGroupsPage();
            App.Groups.SelectGroup(1);
            App.Groups.RemoveGroup();
            App.Groups.ReturnToGroupPage();
            App.Auth.Logout();
        }
    }
}

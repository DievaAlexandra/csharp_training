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
    public class GroupCreationTests : TestBase
    {
       [Test]
        public void GroupCreationTest()
        {
            App.Navigator.GoToHomePage();
            App.Auth.Login(new AccountData("admin", "secret"));
            App.Navigator.GoToGroupsPage();
            App.Groups.InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            App.Groups.SubmitGroupCreation();
            App.Groups.ReturnToGroupPage();
            App.Auth.Logout();
        }
     }
}

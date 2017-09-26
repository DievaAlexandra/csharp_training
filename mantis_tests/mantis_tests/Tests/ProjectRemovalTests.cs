using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
       
        [Test]
        public void ProjectRemovalTest()
        {
            if (!app.Project.ThereAreProject())
                app.Project.Create(new ProjectData(GenerateRandomString(10)));

            List<ProjectData> oldProject = app.Project.GetProjectList();
            

            app.Project.Remove(1);

            Assert.AreEqual(oldProject.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProject = app.Project.GetProjectList();

            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);

         }
    }
}

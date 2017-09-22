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
                app.Project.Create(new ProjectData("новыйпроект"));

            List<ProjectData> oldProject = app.Project.GetProjectList();
            ProjectData toBeRemoved = oldProject[0];

            app.Project.Remove(toBeRemoved);

            Assert.AreEqual(oldProject.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProject = app.Project.GetProjectList();

            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);

         }
    }
}

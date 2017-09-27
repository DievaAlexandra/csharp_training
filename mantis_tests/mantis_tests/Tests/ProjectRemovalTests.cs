using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests.Tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
       
        [Test]
        public void ProjectRemovalTest()
        {
            app.Navigator.GoToProjectPage();

            if (!app.Project.ThereAreProject())
                app.Project.Create(new ProjectData(GenerateRandomString(10)));

            List<ProjectData> oldProject = app.Project.GetProjectList();

            app.Project.DeleteProject(0);

            Assert.AreEqual(oldProject.Count - 1, app.Project.GetProjectCount());

            List<ProjectData> newProject = app.Project.GetProjectList();

            oldProject.RemoveAt(0);
            Assert.AreEqual(oldProject, newProject);

         }
    }
}

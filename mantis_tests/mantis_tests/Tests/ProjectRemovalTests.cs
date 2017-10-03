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
            {
                app.API.CreateNewProject(new AccountData("administrator", "root"), 
                    new ProjectData("test_new_project"));
            }

            List<Mantis.ProjectData> oldProject = app.API.GetProjectList(new AccountData("administrator", "root"));

            
            app.Project.DeleteProject(0);
            

            Assert.AreEqual(oldProject.Count-1, app.Project.GetProjectCount());

            List<Mantis.ProjectData> newProject = app.API.GetProjectList(new AccountData("administrator", "root"));

            oldProject.RemoveAt(0);
            oldProject.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProject, newProject);

         }
    }
}

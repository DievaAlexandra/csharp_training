using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData(GenerateRandomString(10));
            app.Navigator.GoToProjectPage();

            List<ProjectData> oldprojects = app.Project.GetProjectList();

            app.Project.Create(project);

            Assert.AreEqual(oldprojects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newprojects = app.Project.GetProjectList();
            oldprojects.Add(project); 
            oldprojects.Sort();
            newprojects.Sort();
            Assert.AreEqual(oldprojects,newprojects);

        }
    }
}

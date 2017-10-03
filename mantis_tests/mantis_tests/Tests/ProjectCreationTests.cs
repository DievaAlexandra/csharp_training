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
            Mantis.ProjectData project = new Mantis.ProjectData();
            app.Navigator.GoToProjectPage();

            List<Mantis.ProjectData> oldprojects = app.API.GetProjectList(new AccountData("administrator", "root"));

            app.API.CreateNewProject(new AccountData("administrator", "root"),new ProjectData(GenerateRandomString(10)));

            Assert.AreEqual(oldprojects.Count + 1, app.Project.GetProjectCount());

            List<Mantis.ProjectData> newprojects = app.API.GetProjectList(new AccountData("administrator", "root"));
            oldprojects.Add(project); 
            oldprojects.Sort();
            newprojects.Sort();
            Assert.AreEqual(oldprojects,newprojects);

        }
    }
}

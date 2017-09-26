using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData(GenerateRandomString(15)); 
            
            List<ProjectData> oldprojects = app.Project.GetProjectList();//получили старый список проектов

            app.Project.Create(project); //выполнили метод добавления нового проекта 

            //Assert.AreEqual(oldprojects.Count + 1, app.Project.GetProjectCount()); //сравнили количество 

            List<ProjectData> newprojects = app.Project.GetProjectList();//получили новый список проектов
            oldprojects.Add(project); //добавили
            oldprojects.Sort();//отсортировали
            newprojects.Sort();
            Assert.AreEqual(oldprojects,newprojects); // сравнили списки

        }
    }
}

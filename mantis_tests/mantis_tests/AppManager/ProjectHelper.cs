using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectHelper Remove(ProjectData toBeRemoved)
        {
            throw new NotImplementedException();
            return this;
        }

        public ProjectHelper Create(ProjectData projectData)
        {
            throw new NotImplementedException();
            return this;
        }

        //проверка наличия проектов в списке
        public bool ThereAreProject()
        {
            return IsElementPresent(By.CssSelector("td > a"));
        }

        //получение кол-ва элементов в списке
        public int GetProjectCount()
        {
            return driver.FindElements(By.CssSelector("td > a")).Count;
        }
        public List<ProjectData> GetProjectList()
        {
            throw new NotImplementedException();
        }
    }
}

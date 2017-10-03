using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //создание проекта
        public ProjectHelper Create(ProjectData project)
        {
            manager.Navigator.GoToProjectPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        //удаление проекта
        public void DeleteProject(int index)
        {
            manager.Navigator.GoToProjectPage();
            GoToProjectDetailsPage(index);
            driver.FindElement(By.XPath("//*[@id='project-delete-form']")).Submit();
            driver.FindElement(By.XPath("//form[@method='post' and @class='center']")).Submit();
        }

        //проверка наличия проектов в списке
        public bool ThereAreProject()
        {
            return GetProjectCount() > 0;
        }

        //выбор действия "Создать"
        public ProjectHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
            return this;
        }

        //заполнение формы
        private ProjectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            return this;
        }

        //подтверждение действия "Создать"
        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            driver.FindElement(By.LinkText("Proceed")).Click();
            return this;
        }

        //переход в детальную карточку проекта 
        public ProjectHelper GoToProjectDetailsPage(int index)
        {
            manager.Navigator.GoToProjectPage();
            GetProjectLinks()[index].Click();
            return this;
        }
        
        public List<IWebElement> GetProjectLinks()
        {
            return driver.FindElements(By.XPath("//a[contains(@href, 'manage_proj_edit_page')]")).ToList();
        }

        //удаление
        private ProjectHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            return this;
        }
        
        //получение кол-ва элементов в списке
        public int GetProjectCount()
        {
            var widgets = driver.FindElements(By.CssSelector(".main-content .widget-box"));
            var projects = widgets[0];
            var tablerows = projects.FindElements(By.CssSelector("table tbody tr"));

            return tablerows.Count;
        }

        //получение списка элементов
        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();

                var pr = GetProjectLinks();

                foreach (var row in pr)
                {
                   projectCache.Add(new ProjectData(row.Text));
                }
            }
            return projectCache;
        
        }
    }
}


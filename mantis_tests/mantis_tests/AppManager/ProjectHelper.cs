using System;
using System.Collections;
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
        public ProjectHelper Remove(int i)
        {
            manager.Navigator.GoToProjectPage();
            GoToDetailsPageProject(i);
            RemoveProject();
            return this;
        }


        //проверка наличия проектов в списке
        public bool ThereAreProject()
        {
            return true;
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

        //выбор проекта 
        public ProjectHelper GoToDetailsPageProject(int i)
        {
            driver.FindElement(By.CssSelector("td > a")).Click();
            return this;
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
            return 1;
        }

        //получение списка элементов
        public List<ProjectData> GetProjectList()
        {
         return new List<ProjectData>();
        }
    }
}

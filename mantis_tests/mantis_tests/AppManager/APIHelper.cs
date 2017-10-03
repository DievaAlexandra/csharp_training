using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mantis_tests.Mantis;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
      public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        //создание баг репорта
        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData
            {
                summary = issueData.Summary,
                description = issueData.Description,
                category = issueData.Category,
                project = new Mantis.ObjectRef {id = project.Id}
            };
            client.mc_issue_add(account.Username, account.Password, issue);
        }

        //создание проекта 
        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;

            client.mc_project_add(account.Username, account.Password, project);
        }

      
        //получение списка элементов
        
        public List<Mantis.ProjectData> GetProjectList(AccountData account)
        {
           
            driver.Navigate().Refresh();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<Mantis.ProjectData> project = client.mc_projects_get_user_accessible(account.Username, account.Password).ToList();


            return project;
            

        }

    }

}

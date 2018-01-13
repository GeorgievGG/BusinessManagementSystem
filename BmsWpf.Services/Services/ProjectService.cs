namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using MoreLinq;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class ProjectService : IProjectService
    {
        private IBmsData bmsData;

        public ProjectService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public DataTable GetProjectsAsDataTable()
        {
            var projects = this.GetActiveProjects();
            var dataTable = this.GetProjectsAsDataTable(projects);
            return dataTable;
        }

        public DataTable FilterProjects(DateTime beginDate, DateTime endDate)
        {
            var projects = this.GetActiveProjects();
            var chosenProjects = projects.Where(x => x.StartDate >= beginDate && x.StartDate <= endDate);
            var chosenDataTable = this.GetProjectsAsDataTable(chosenProjects);
            return chosenDataTable;
        }

        public IEnumerable<ProjectListDto> GetProjectsForDropdown()
        {
            var projectNames = this.GetActiveProjects().Select(x => new ProjectListDto()
                                    {
                                        Id = x.Id,
                                        Name = x.Name
                                    });
            return projectNames;
        }

        private DataTable GetProjectsAsDataTable(IQueryable<Project> projects)
        {
            var dataTable = projects.Select(x => new ProjectsMainWindowDto
            {
                Id = x.Id,
                Name = x.Name,
                Offer = new OfferListDto
                {
                    Id = x.Offer.Id,
                    Description = x.Offer.Description
                },
                Inquiry = new InquiryListDto
                {
                    Id = x.Inquiry.Id,
                    Description = x.Inquiry.Description
                },
                Creator = new UserListDto
                {
                    Id = x.Creator.Id,
                    Username = x.Creator.Username
                },
                Client = new ContragentListDto
                {
                    Id = x.Contragent.Id,
                    NameAndIdentity = x.Contragent.Name
                },
                ContactPerson = x.ContactPerson,
                ContactPhone = x.ContactPhone,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Deadline = x.DeadLine,
                Incomes = x.Invoices.Where(i => i.SupplierId == 1).Sum(i => i.Total),
                Expenses = x.Invoices.Where(i => i.ClientId == 1).Sum(i => i.Total)
            })
                                    .ToDataTable();
            return dataTable;
        }

        private IQueryable<Project> GetActiveProjects()
        {
            return bmsData.Projects.All();//.Where(x => x.EndDate == null);
        }

        public string CreateProject(ProjectPostDto newProject)
        {
            var project = new Project()
            {
                Name = newProject.Name,
                OfferId = newProject.OfferId,
                InquiryId = newProject.InquiryId,
                CreatorId = newProject.CreatorId,
                ContragentId = newProject.ClientId,
                ContactPerson = newProject.ContactPerson,
                ContactPhone = newProject.ContactPhone,
                StartDate = newProject.StartDate,
                DeadLine = newProject.Deadline,
                EndDate = newProject.EndDate
            };

            this.bmsData.Projects.Add(project);
            this.bmsData.SaveChanges();

            return $"Project \"{newProject.Name}\" from date {newProject.StartDate.ToShortDateString()} successfully created!";
        }

        public string EditProject(ProjectPostDto newProject)
        {
            var project = bmsData.Projects.Find(newProject.Id);

            project.Name = newProject.Name;
            project.OfferId = newProject.OfferId;
            project.InquiryId = newProject.InquiryId;
            project.CreatorId = newProject.CreatorId;
            project.ContragentId = newProject.ClientId;
            project.ContactPerson = newProject.ContactPerson;
            project.ContactPhone = newProject.ContactPhone;
            project.StartDate = newProject.StartDate;
            project.DeadLine = newProject.Deadline;
            project.EndDate = newProject.EndDate;

            this.bmsData.Projects.Update(project);
            this.bmsData.SaveChanges();

            return $"Project {newProject.Name} successfully updated!";
        }

        public string Delete(int id)
        {
            var project = this.bmsData.Projects.Find(id);

            try
            {
                this.bmsData.Projects.Remove(project);
                this.bmsData.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                var innerException = dbEx.InnerException;
                if (innerException is SqlException)
                {
                    var sqlEx = (SqlException)innerException;
                    if (sqlEx.Errors.Count > 0 && sqlEx.Errors[0].Number == 547) // Foreign Key violation
                    {
                        throw new InvalidOperationException("You cannot delete that project!");
                    }
                }
                throw dbEx;
            }

            return $"You deleted project {project.Id} from {project.StartDate.ToShortDateString()} successfully";
        }
    }
}

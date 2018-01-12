namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using MoreLinq;
    using System;
    using System.Collections.Generic;
    using System.Data;
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
    }
}

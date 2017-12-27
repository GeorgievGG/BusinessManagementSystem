namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using System;
    using System.Linq;

    public class ProjectService : IProjectService
    {
        private IBmsData bmsData;

        public ProjectService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public IQueryable<string> FilterProjects(DateTime beginDate, DateTime endDate)
        { 
            var chosenProjects = this.GetActiveProjects().Where(x => x.StartDate >= beginDate && x.StartDate <= endDate);
            return chosenProjects.Select(x => $"Project {x.Name} from {x.StartDate.ToShortDateString()}");
        }

        public IQueryable<string> GetProjects()
        {
            var activeProjects = this.GetActiveProjects().Select(x => $"Project \"{x.Name}\" from {x.StartDate.ToShortDateString()}");
            return activeProjects;
        }

        private IQueryable<Project> GetActiveProjects()
        {
            return bmsData.Projects.All().Where(x => x.EndDate == null);
        }
    }
}

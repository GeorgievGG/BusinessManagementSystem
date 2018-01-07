namespace BmsWpf.Services.Contracts
{
    using BmsWpf.Services.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IProjectService
    {
        IQueryable<string> GetProjects();
        IQueryable<string> FilterProjects(DateTime beginDate, DateTime endDate);
        IEnumerable<ProjectListDto> GetProjectsForDropdown();
    }
}
namespace BmsWpf.Services.Contracts
{
    using BmsWpf.Services.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public interface IProjectService
    {
        DataTable FilterProjects(DateTime beginDate, DateTime endDate);
        IEnumerable<ProjectListDto> GetProjectsForDropdown();
        DataTable GetProjectsAsDataTable();
        string CreateProject(ProjectPostDto newProject);
        string EditProject(ProjectPostDto newProject);
    }
}
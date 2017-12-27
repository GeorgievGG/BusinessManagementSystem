using System;
using System.Linq;
using BMS.DataBaseModels;

namespace BmsWpf.Services.Contracts
{
    public interface IProjectService
    {
        IQueryable<string> GetProjects();
        IQueryable<string> FilterProjects(DateTime beginDate, DateTime endDate);
    }
}
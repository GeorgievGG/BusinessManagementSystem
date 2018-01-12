namespace BmsWpf.Services.Services
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using MoreLinq;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class NoteService : INoteService
    {
        private IBmsData bmsData;

        public NoteService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public DataTable GetNotesAsDataTable()
        {
            var dataTable = this.GetNotesDto()
                                    .ToDataTable();
            return dataTable;
        }

        public DataTable GetLast5NotesAsDataTable()
        {
            var top5Notes = this.GetNotesDto()
                .OrderByDescending(x => x.Date)
                .Take(5)
                .ToDataTable();

            return top5Notes;
        }

        private IEnumerable<NotesGetDto> GetNotesDto()
        {
            var notes = this.bmsData
                                .Notes
                                .All();
            var notesDtos = notes.Select(x => new NotesGetDto
            {
                Id = x.Id,
                Description = x.Description,
                Project = new ProjectListDto()
                {
                    Id = x.Project.Id,
                    Name = x.Project.Name
                },
                Date = x.Date,
                Type = x.Type
            });

            return notesDtos;
        }

    }
}

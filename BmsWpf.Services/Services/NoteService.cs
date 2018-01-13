namespace BmsWpf.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;

    using Microsoft.EntityFrameworkCore;

    using MoreLinq;

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

        public DataTable GetNotesAsDataTable(int projectId)
        {
            var notes = this.GetNotesDto()
                .Where(x => x.Project.Id == projectId)
                .ToDataTable();
            return notes;
        }

        public DataTable GetLast5NotesAsDataTable(int projectId)
        {
            var last5Notes = this.GetNotesDto().Where(x => x.Project.Id == projectId)
                .OrderByDescending(x => x.Date)
                .Take(5)
                .ToDataTable();

            return last5Notes;
        }

        public string Delete(int id)
        {
            var note = this.bmsData.Notes.Find(id);

            try
            {
                this.bmsData.Notes.Remove(note);
                this.bmsData.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {

                var innerException = dbEx.InnerException;
                if (innerException is SqlException)
                {
                    var sqlEx = (SqlException)innerException;
                    if (sqlEx.Errors.Count > 0)
                    {
                        throw new InvalidOperationException("You cannot delete this event!");
                    }
                }
                throw dbEx;
            }
            return $"You deleted note {note.Id} from {note.Date} successfully";
        }


        public string EditNote(NotePostDto newNote)
        {
            var noteToUpdate = this.bmsData.Notes.Find(newNote.Id);
            noteToUpdate.Type = newNote.Type;
            noteToUpdate.Date = newNote.Date;
            noteToUpdate.Description = newNote.Description;
            noteToUpdate.ProjectId = newNote.ProjectId;

            this.bmsData.Notes.Update(noteToUpdate);
            this.bmsData.SaveChanges();

            return $"Note was updated";

        }

        public string CreateNote(NotePostDto newNote)
        {
            var userSvr = new UserService(this.bmsData);

            var note = new Note()
            {
                Id = newNote.Id,
                Type = newNote.Type,
                Date = newNote.Date,
                Description = newNote.Description,
                ProjectId = newNote.ProjectId
            };
            this.bmsData.Notes.Add(note);
            this.bmsData.SaveChanges();

            return $"Note was saved!";
        }

    }
}

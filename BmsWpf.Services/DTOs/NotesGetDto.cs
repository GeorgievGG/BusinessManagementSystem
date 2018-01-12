namespace BmsWpf.Services.DTOs
{
    using BMS.DataBaseModels.Enums;
    using System;

    public class NotesGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ProjectListDto Project { get; set; }
        public DateTime Date { get; set; }
        public NoteType Type { get; set; }
    }
}

namespace BMS.DataBaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BMS.DataBaseModels.Enums;

    public class Note
    {
        [Key]
        public int Id { get; set; }
        public NoteType Type { get; set; }
        public DateTime Date { get; set; }
        
        public string Description { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

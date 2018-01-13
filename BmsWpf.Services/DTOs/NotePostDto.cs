namespace BmsWpf.Services.DTOs
{
    using System;

    using BMS.DataBaseModels.Enums;

    public class NotePostDto
    {
        private NoteType type;
        private string description;
        private int projectId;

        public int Id { get; set; }
        public NoteType Type {
            get
            {
                return this.type;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You have to choose a type");
                }

                this.type = value;
            }
        }
        public DateTime Date { get; set; }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Description have to be more then 3 symbols");
                }

                this.description = value;
            }
        }
        public int ProjectId {
            get
            {
                return this.projectId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a project!");
                }
                this.projectId = value;
            }
        }
  
    }
}

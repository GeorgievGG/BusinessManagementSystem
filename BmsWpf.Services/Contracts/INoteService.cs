using System.Data;

namespace BmsWpf.Services.Contracts
{
    public interface INoteService
    {
        DataTable GetNotesAsDataTable();
        DataTable GetLast5NotesAsDataTable();
        DataTable GetNotesAsDataTable(int projectId);
        DataTable GetLast5NotesAsDataTable(int projectId);
    }
}
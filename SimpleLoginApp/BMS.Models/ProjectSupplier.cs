namespace WpfApp1.Models
{
    public class ProjectSupplier
    {
        public int SupplierId { get; set; }
        public Contragent Supplier { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

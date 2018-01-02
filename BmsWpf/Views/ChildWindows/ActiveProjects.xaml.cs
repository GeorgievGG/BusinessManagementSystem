namespace BmsWpf.Views.ChildWindows
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    using BmsWpf.Views.Forms;
    using BMS.DataBaseData;
    using System.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// Interaction logic for ActiveProjects.xaml
    /// </summary>
    public partial class ActiveProjects : Window
    {
        public ActiveProjects()
        {
            InitializeComponent();
        }

        public ActiveProjects(IViewManager viewManager, IProjectService projectService)
        {
            InitializeComponent();

            var vm = (ActiveProjectsViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.ProjectService = projectService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addNewProject = new ProjectWindow();
            addNewProject.Show();
            this.Close();
        }

        public void fillingDataGrid()
        {
            var db = new BmsContex();
            DataTable dt = new DataTable();
            DataColumn projectId = new DataColumn("Id", typeof(int));
            DataColumn projectName = new DataColumn("Name", typeof(string));
            DataColumn client = new DataColumn("Client", typeof(string));
            DataColumn clientPersonOfContact = new DataColumn("Contact", typeof(string));
            DataColumn clientPhone = new DataColumn("Phone", typeof(string));
            DataColumn offer = new DataColumn("Offer", typeof(string));
            DataColumn inquiry = new DataColumn("Inquiry", typeof(string));
            DataColumn creator = new DataColumn("Creator", typeof(string));
            DataColumn startDate = new DataColumn("StartDate", typeof(string));
            DataColumn deadLine = new DataColumn("Deadline", typeof(string));

            dt.Columns.Add(projectId);
            dt.Columns.Add(projectName);
            dt.Columns.Add(client);
            dt.Columns.Add(clientPersonOfContact);
            dt.Columns.Add(clientPhone);
            dt.Columns.Add(offer);
            dt.Columns.Add(inquiry);
            dt.Columns.Add(creator);
            dt.Columns.Add(startDate);
            dt.Columns.Add(deadLine);


            var projects = db.Projects.Include(e => e.Offer).Include(e => e.Creator).Include(e => e.Inquiry).Include(e => e.Contragent).ToArray();

            foreach (var project in projects)
            {
                DataRow row = dt.NewRow();
                row[0] = project.Id;
                row[1] = project.Name;
                row[2] = project.Contragent.Name;
                row[3] = project.Contragent.PersonForContact;
                row[4] = project.Contragent.Telephone;
                row[5] = project.Offer.Description;
                row[6] = project.Inquiry.Description;
                row[7] = project.Creator.Username;
                row[8] = project.StartDate.ToShortDateString();
                row[9] = project.DeadLine.ToShortDateString();
                dt.Rows.Add(row);
            }

            ProjectsDataGrid.ItemsSource = dt.DefaultView;
        }

        private void ProjectsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }



        private void ProjectsDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //bind edit project form

            var addNewProject = new ProjectWindow();
            addNewProject.Show();
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var db = new BmsContex();
            DataTable dt = new DataTable();
            DataColumn projectId = new DataColumn("Id", typeof(int));
            DataColumn projectName = new DataColumn("Name", typeof(string));
            DataColumn client = new DataColumn("Client", typeof(string));
            DataColumn clientPersonOfContact = new DataColumn("Contact", typeof(string));
            DataColumn clientPhone = new DataColumn("Phone", typeof(string));
            DataColumn offer = new DataColumn("Offer", typeof(string));
            DataColumn inquiry = new DataColumn("Inquiry", typeof(string));
            DataColumn creator = new DataColumn("Creator", typeof(string));
            DataColumn startDate = new DataColumn("StartDate", typeof(string));
            DataColumn deadLine = new DataColumn("Deadline", typeof(string));

            dt.Columns.Add(projectId);
            dt.Columns.Add(projectName);
            dt.Columns.Add(client);
            dt.Columns.Add(clientPersonOfContact);
            dt.Columns.Add(clientPhone);
            dt.Columns.Add(offer);
            dt.Columns.Add(inquiry);
            dt.Columns.Add(creator);
            dt.Columns.Add(startDate);
            dt.Columns.Add(deadLine);

            var fromDate = this.fromDater.SelectedDate.Value.Date;
            var toDate = this.toDater.SelectedDate.Value.Date;

            var projects = db.Projects.Where(p => p.StartDate.Date >= fromDate && p.StartDate.Date <= toDate).Include(p => p.Offer).Include(p => p.Creator).Include(p => p.Inquiry).Include(p => p.Contragent).ToArray();


            foreach (var project in projects)
            {
                DataRow row = dt.NewRow();
                row[0] = project.Id;
                row[1] = project.Name;
                row[2] = project.Contragent.Name;
                row[3] = project.Contragent.PersonForContact;
                row[4] = project.Contragent.Telephone;
                row[5] = project.Offer.Description;
                row[6] = project.Inquiry.Description;
                row[7] = project.Creator.Username;
                row[8] = project.StartDate.ToShortDateString();
                row[9] = project.DeadLine.ToShortDateString();
                dt.Rows.Add(row);
            }

            ProjectsDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}

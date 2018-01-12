namespace BmsWpf.Views.ActiveProjectForms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.Services;
    using BmsWpf.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for ProjectOverviewTabView.xaml
    /// </summary>
    public partial class ProjectOverviewView : UserControl
    {
        public ProjectOverviewView()
        {
            InitializeComponent();
        }

        //public ProjectOverviewView()
        //{
        //    InitializeComponent();

        //    PFOverviewViewModel vm = (PFOverviewViewModel)this.DataContext; // this creates an instance of the ViewModel

        //    vm.ViewManager = viewManager;
        //    vm.InquiryService = inquiryService;
        //    vm.ContragentService = contragentService;
        //    vm.UserService = userService;
        //    vm.OfferService = offerService;
        //    vm.NoteService = noteService;
        //    vm.ProjectService = projectService;
        //}
    }
}

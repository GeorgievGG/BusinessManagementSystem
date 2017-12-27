namespace BmsWpf
{
    using BmsWpf.Services.Automapper;
    using BmsWpf.Services.Services;
    using BmsWpf.Views.Admin;
    using BmsWpf.Views.ChildWindows;
    using System.Windows;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewManager = new ViewManager();
            Current.MainWindow = viewManager.ComposeObjects<ActiveProjects>();
            Current.MainWindow.Show();
            //AutoMapperConfiguration.Configure();
        }
    }
}

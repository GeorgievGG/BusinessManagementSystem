namespace BmsWpf
{
    using BmsWpf.Services.Services;
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;
    using System.Windows;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewManager = new ViewManager();
            Current.MainWindow = viewManager.ComposeObjects<LoginForm>();
            Current.MainWindow.Show();
            //AutoMapperConfiguration.Configure();
        }
    }
}

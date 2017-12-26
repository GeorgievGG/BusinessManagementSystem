namespace BmsWpf
{
    using BmsWpf.Views.Forms;
    using System.Windows;
    using Ninject;
    using BmsWpf.Services.UnitOfWork;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.Services;

    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewManager = new ViewManager();
            Current.MainWindow = viewManager.ComposeObjects<LoginForm>();
            Current.MainWindow.Show();
        }
    }
}

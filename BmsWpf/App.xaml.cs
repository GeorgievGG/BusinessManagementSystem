namespace BmsWpf
{
    using BmsWpf.Views.Forms;
    using System.Windows;
    using Ninject;
    using BmsWpf.Services.UnitOfWork;
    using BmsWpf.Services.Contracts;

    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ConfigureContainer();
            this.ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IBmsData>().To<BmsData>().InTransientScope();
        }

        public void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<LoginForm>();
        }
    }
}

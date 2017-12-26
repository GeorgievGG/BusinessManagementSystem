namespace BmsWpf.Services.Services
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.UnitOfWork;
    using Ninject;

    public class ViewManager : IViewManager
    {
        private IKernel container;

        public ViewManager()
        {
            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IBmsData>().To<BmsData>().InTransientScope();
            container.Bind<IViewManager>().To<ViewManager>().InTransientScope();
            container.Bind<IUserService>().To<UserService>().InTransientScope();
        }

        public T ComposeObjects<T>()
        {
            return this.container.Get<T>();
        }
    }
}

namespace BmsWpf.Services.Services
{
    using BMS.DataBaseData;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.UnitOfWork;
    using Microsoft.EntityFrameworkCore;
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
            container.Bind<DbContext>().To<BmsContex>().InTransientScope();
            container.Bind<IBmsData>().To<BmsData>().InTransientScope();
            container.Bind<IViewManager>().To<ViewManager>().InTransientScope();
            container.Bind<IUserService>().To<UserService>().InTransientScope();
            container.Bind<IProjectService>().To<ProjectService>().InTransientScope();
            container.Bind<IInquiryService>().To<InquiryService>().InTransientScope();
            container.Bind<IOfferService>().To<OfferService>().InTransientScope();
            container.Bind<IContragentService>().To<ContragentService>().InTransientScope();
            container.Bind<IInvoiceService>().To<InvoiceService>().InTransientScope();
            container.Bind<ICalendarEventService>().To<CalendarEventService>().InTransientScope();
        }

        public T ComposeObjects<T>()
        {
            return this.container.Get<T>();
        }
    }
}

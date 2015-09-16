using Autofac;
using Caliburn.Micro;
using MSBandAzure.Services;
using MSBandAzure.ViewModels;

namespace MSBandAzure.Mvvm
{
    public class VMLocator
    {
        private IContainer _container;

        public VMLocator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainPageViewModel>().SingleInstance();
            builder.RegisterType<MSBandService>().As<IBandService>().SingleInstance();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            _container = builder.Build();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return _container.Resolve<MainPageViewModel>();
            }
        }
    }
}

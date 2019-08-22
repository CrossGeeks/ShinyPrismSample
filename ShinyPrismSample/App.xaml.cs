using System;
using Prism.DryIoc;
using Prism.Ioc;
using Shiny.Locations;
using ShinyPrismSample.ViewModels;

namespace ShinyPrismSample
{
    public partial class App : PrismApplication
    {
        protected override IContainerExtension CreateContainerExtension() => PrismContainerExtension.Current;

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage,MainPageViewModel>();
        }
        /*
        protected override void OnStart()
        {
            base.OnStart();
            Shiny.ShinyHost.Resolve<IGpsManager>().StartListener(new GpsRequest
            {
                UseBackground = true,
                Priority = GpsPriority.Highest,
                Interval = TimeSpan.FromSeconds(5),
                ThrottledInterval = TimeSpan.FromSeconds(3) //Should be lower than Interval
            });
        }*/
    }
}

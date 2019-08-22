using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Shiny;
using Shiny.Prism;
using ShinyPrismSample.Delegates;
using static ShinyPrismSample.Delegates.GpsListener;

namespace ShinyPrismSample
{ 
    public class ShinyAppStartup : PrismStartup
    {
        public ShinyAppStartup(): base(PrismContainerExtension.Current)
        {

        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGpsListener, GpsListener>();
            services.UseGps<LocationDelegate>();
        }
    }
}

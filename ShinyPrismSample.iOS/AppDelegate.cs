using Foundation;
using Shiny;
using UIKit;

namespace ShinyPrismSample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            iOSShinyHost.Init(new ShinyAppStartup());

            global::Xamarin.Forms.Forms.Init();
            this.LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

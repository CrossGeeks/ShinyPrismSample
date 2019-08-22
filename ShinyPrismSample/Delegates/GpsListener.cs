using System;
using System.Threading.Tasks;
using Shiny.Locations;

namespace ShinyPrismSample.Delegates
{
    public class GpsListener : IGpsListener
    {
        public event EventHandler<GpsReadingEventArgs> OnReadingReceived;

        void UpdateReading(IGpsReading reading)
        {
            OnReadingReceived?.Invoke(this, new GpsReadingEventArgs(reading));
        }


        public class LocationDelegate : IGpsDelegate
        {
            IGpsListener _gpsListener;

            public LocationDelegate(IGpsListener gpsListener)
            {
                _gpsListener = gpsListener;
            }

            public Task OnReading(IGpsReading reading)
            {
                (_gpsListener as GpsListener)?.UpdateReading(reading);
                return Task.CompletedTask;
            }
         }
    }
}

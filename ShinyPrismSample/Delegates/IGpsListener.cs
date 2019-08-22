using System;
using Shiny.Locations;

namespace ShinyPrismSample.Delegates
{
    public class GpsReadingEventArgs : EventArgs
    {
        public IGpsReading Reading { get; }

        public GpsReadingEventArgs(IGpsReading reading)
        {
            Reading = reading;
        }

    }


    public interface IGpsListener
    {
        event EventHandler<GpsReadingEventArgs> OnReadingReceived;
    }
}

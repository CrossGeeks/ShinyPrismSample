using System;
using System.ComponentModel;
using System.Diagnostics;
using Prism.Navigation;
using Shiny.Locations;
using ShinyPrismSample.Delegates;

namespace ShinyPrismSample.ViewModels
{
    public class MainPageViewModel : INavigatedAware, INotifyPropertyChanged, IDestructible
    {
        IGpsListener _gpsListener;
        IGpsManager _gpsManager;

        public event PropertyChangedEventHandler PropertyChanged;

        public string LocationMessage { get; set; }

        public MainPageViewModel(IGpsManager gpsManager,IGpsListener gpsListener)
        {
            _gpsManager = gpsManager;
            _gpsListener = gpsListener;
            _gpsListener.OnReadingReceived += OnReadingReceived;
        }

        void OnReadingReceived(object sender, GpsReadingEventArgs e)
        {
            LocationMessage = $"{e.Reading.Position.Latitude}, {e.Reading.Position.Longitude}";
            Debug.WriteLine(LocationMessage);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
   
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (_gpsManager.IsListening)
            {
                await _gpsManager.StopListener();
            }

            await _gpsManager.StartListener(new GpsRequest
            {
                UseBackground = true,
                Priority = GpsPriority.Highest,
                Interval = TimeSpan.FromSeconds(5),
                ThrottledInterval = TimeSpan.FromSeconds(3) //Should be lower than Interval
            });
        }

        public void Destroy()
        {
             _gpsListener.OnReadingReceived -= OnReadingReceived;
        }
    }
}

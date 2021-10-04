using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6_Mod5_Act1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeocodingPage : ContentPage
    {
        public GeocodingPage()
        {
            InitializeComponent();
            GetAddressCommand = new Command(async () => await OnGetAddress());
            GetPositionCommand = new Command(async () => await OnGetPosition());
            BindingContext = this;
        }
        string lat = "25.632331";
        string lon = "-122.123424";
        string address = "Sta. Prisca";
        string geocodeAddress;
        string geocodePosition;

        public ICommand GetAddressCommand { get; }

        public ICommand GetPositionCommand { get; }

        public string Latitude
        {
            get => lat;
            set => SetProperty(ref lat, value);
        }
        public string Longitude
        {
            get => lon;
            set => SetProperty(ref lon, value);
        }
        public string GeocodeAddress
        {
            get => geocodeAddress;
            set => SetProperty(ref geocodeAddress, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string GeocodePosition
        {
            get => geocodePosition;
            set => SetProperty(ref geocodePosition, value);
        }

        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null, Func<T, T, bool> validateValue = null
            )
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            if (validateValue != null && !validateValue(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        async Task OnGetAddress()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                double.TryParse(lat, out var lt);
                double.TryParse(lat, out var ln);
                var placemarks = await Geocoding.GetPlacemarksAsync(lt, ln);
                Placemark placemark = placemarks.FirstOrDefault();
                if (placemark == null)
                {
                    GeocodeAddress = "Unable to detect placemark";
                }
                else
                {
                    GeocodeAddress = $"{nameof(placemark.AdminArea)}: {placemark.AdminArea}\n" +
                                $"{nameof(placemark.CountryName)}: {placemark.CountryName}\n" +
                                $"{nameof(placemark.Locality)}: {placemark.Locality}\n";
                }
            }
            catch (Exception ex)
            {
                GeocodeAddress = $"Unable to detect placemarks: {ex.Message}";
            }
        }
        async Task OnGetPosition()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                var locations = await Geocoding.GetLocationsAsync(Address);
                Location location = locations.FirstOrDefault();
                if (location == null)
                {
                    GeocodePosition = "Unable to detect location. Please try again";
                }
                else
                {
                    GeocodePosition = $"{nameof(location.Latitude)}: {location.Latitude}\n" +
                        $"{nameof(location.Longitude)}: {location.Longitude}\n";
                }
            }
            catch (Exception ex)
            {
                GeocodePosition = $"Unable to detect locations: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
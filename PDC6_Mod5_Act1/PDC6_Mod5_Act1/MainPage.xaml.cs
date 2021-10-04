using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC6_Mod5_Act1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void AccelerometerPage_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccelerometerPage());
        }
        private async void BarometerPage_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BarometerPage());
        }
        private async void ConnectivityPage_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConnectivityPage());
        }
        private async void MagnetometerPage_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MagnetometerPage());
        }
        private async void GeolocationPage_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GeolocationPage());
        }
        private async void BatteryPage_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BatteryPage());
        }





        /* private async void AccelerometerPage_CLicked(Object sender, EventArgs e)
{
    await Navigation.PushAsync(new AccelerometerPage());
}
private async void BarometerPage_CLicked(Object sender, EventArgs e)
{
    await Navigation.PushAsync(new BarometerPage());
}
private async void ConnectivityPage_CLicked(Object sender, EventArgs e)
{
    await Navigation.PushAsync(new ConnectivityPage());
}
private async void MagnetometerPage_CLicked(Object sender, EventArgs e)
{
    await Navigation.PushAsync(new MagnetometerPage());
}*/

    }
}

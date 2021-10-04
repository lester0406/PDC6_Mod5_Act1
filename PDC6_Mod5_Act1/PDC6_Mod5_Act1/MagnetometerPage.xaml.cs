using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PDC6_Mod5_Act1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MagnetometerPage : ContentPage
    {
        public MagnetometerPage()
        {
            InitializeComponent();
            try
            {
                Magnetometer.ReadingChanged += ReadingChanged;
                Magnetometer.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException fnsEX)
            {
                lblMeasure.Text = fnsEX.Message;
            }
            catch(Exception ex)
            {
                lblMeasure.Text = ex.Message;
            }
        }
        void ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            var data = e.Reading;
            lblMeasure.Text = $"Reading: X: {data.MagneticField.X}, Y :{data.MagneticField.Y}, Z:{data.MagneticField.Z}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tools : ContentPage
    {
        public Tools()
        {
            InitializeComponent();
        }

        private async void BtnHospital_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new hospitales());
        }

        private async void BtnEnfermo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new enfermos());
        }

        private async void BtnOcupacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ocupacion());
        }

        private async void BtnPlantilla_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new plantilla());
        }

        private async void BtnSala_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new sala());
        }
    }
}
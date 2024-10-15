using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hospital.modelo;
using Hospital.servicios;
using Hospital.vista;
using Hospital.vistamodelo;

namespace Hospital
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPresentation());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

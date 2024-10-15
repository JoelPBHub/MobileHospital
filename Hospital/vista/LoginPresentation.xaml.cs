using Hospital.vista.ResumenHospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPresentation : ContentPage
    {
        public LoginPresentation()
        {
            InitializeComponent();
            Animation();
        }

        public async Task Animation()
        {
            Logo.Opacity = 0;
            await Logo.FadeTo(1, 2000);
            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
             {
                Application.Current.MainPage = new NavigationPage(new Menu());

             }
            else
            {
                App.Current.MainPage = new PrimerosPasos();
            }
            
        }

    }
}
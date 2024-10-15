using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Hospital.vistamodelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSession : ContentPage
    {
        public LoginSession()
        {
            InitializeComponent();
        }

       

        private async void btnNewAccount_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new MakeUser());
        }

        private async void btnIniciarLog_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserLog.Text))
            {
                if (!string.IsNullOrEmpty(Passlog.Text))
                {

                    UserDialogs.Instance.ShowLoading("Cargando...");
                    await ValidarDatos();

                }
                else
                {
                    await DisplayAlert("Alerta", "Ingrese su contraseña", "OK");
                }
            }

            else
            {
                await DisplayAlert("Alerta", "Ingrese su correo", "OK");
            }

         }

            
        

        private async Task ValidarDatos()
        {

            try
            {
                var funcion = new VMMakeUser();
                await funcion.AuthUser(UserLog.Text, Passlog.Text);
                UserDialogs.Instance.HideLoading();
                Application.Current.MainPage = new NavigationPage(new Menu());
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", "Datos incorrectos", "OK");


            }
            
        }

    }
}
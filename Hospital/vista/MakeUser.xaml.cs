using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Hospital.vistamodelo;
using Hospital.modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeUser : ContentPage
    {
        public MakeUser()
        {
            InitializeComponent();
            CerrarSession();
        }

        string id_user;
        private async void btnMakeUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            if (!string.IsNullOrEmpty(txtUser.Text))
            {
                if (!string.IsNullOrEmpty(txtCorreo.Text))
                {
                    if (!string.IsNullOrEmpty(txtContraseña.Text))
                    {
                       await CrearCuenta();
                       await LoginMaked();
                       await GetIDUser();
                       await PutUser();
                    }

                    else
                    {
                        await DisplayAlert("Alerta", "Agrega una contraseña", "OK");
                    }
                }

                else
                {
                    await DisplayAlert("Alerta", "Agrega un correo", "OK");
                }
            }

            else
            {
                await DisplayAlert("Alerta", "Agrega el nombre", "OK");
            }

        }

        private void CerrarSession()
        {
            Preferences.Remove("MyFirebaseRefreshToken");

        }

        private async Task CrearCuenta()
        {
            var funcion = new VMMakeUser();
            await funcion.CreateUser(txtCorreo.Text, txtContraseña.Text);
        }

        private async Task LoginMaked()
        {
            var funcion = new VMMakeUser();
            await funcion.AuthUser(txtCorreo.Text, txtContraseña.Text);
        }

        private async Task GetIDUser()
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConstanteLog.WebapyFirebase));
                var saveId = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var RefreshContenido = await authProvider.RefreshAuthAsync(saveId);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshContenido));
                id_user = saveId.User.LocalId;

            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "Sesión Expirada", "OK");

            }
        }

        private async Task PutUser()

        {
            var funcion = new VMUsuario();
            var parametros = new musuario();
            parametros.nombre = txtUser.Text;
            parametros.correo = txtCorreo.Text;
            parametros.id_user = id_user;
            parametros.password = txtContraseña.Text;
            await funcion.IsertUser(parametros);
            await DisplayAlert("listo", "Volver a abrir la aplicación", "ok");
            Process.GetCurrentProcess().CloseMainWindow();

        }



    }
}

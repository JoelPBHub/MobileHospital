using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Auth;
using Newtonsoft.Json;
using Hospital.vistamodelo;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Hospital.vistamodelo

{ 


    class VMMakeUser
    {
		
	    public async Task CreateUser(string correo, string contraseña)
	    {
		var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConstanteLog.WebapyFirebase));
			var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(correo, contraseña);
        }

		public async Task AuthUser(string correo, string contraseña)
		{
			try
            {
				var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConstanteLog.WebapyFirebase));
				var auth = await authProvider.SignInWithEmailAndPasswordAsync(correo, contraseña);
				var serializarToken = JsonConvert.SerializeObject(auth);
				Preferences.Set("MyFirebaseRefreshToken", serializarToken);
				await App.Current.MainPage.DisplayAlert("Listo", "Cuenta Registrada", "OK");
			}
			catch
            {
				await App.Current.MainPage.DisplayAlert("Error", "Cuenta y Contraseña Incorrecta", "OK");
			}

		
		}
		   
	}
}

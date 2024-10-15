using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.vista;
using Hospital.vistamodelo;
using Hospital.modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class hospitales : ContentPage
    {
        public hospitales()
        {
            InitializeComponent();
        }



        private async void Btnguardar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await insertar_hospitales();
        }
        private async Task insertar_hospitales()

        { 
         vmhospital funcion = new vmhospital();
         mhospitales parametros = new mhospitales();
            parametros.nombre = txtnombre.Text;
            parametros.direccion = txtdireccion.Text;
            parametros.telefono = txttelefono.Text; 
            parametros.hospital_cod = txthospital_cod.Text;
            parametros.num_cama = txtnum_cama.Text;
            await funcion.insertar_hospitales(parametros);
            await DisplayAlert("listo", "Paciente agregado", "ok");
        }

        private async Task mostrarhospital()

        {
            vmhospital funcion = new vmhospital();
            var dt = await funcion.mostrar_hospitales();
        }
    }

}
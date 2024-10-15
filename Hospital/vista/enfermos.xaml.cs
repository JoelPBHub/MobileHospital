using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.vistamodelo;
using Hospital.modelo;
using Hospital.vista;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class enfermos : ContentPage
    {
        public enfermos()
        {
            InitializeComponent();
        }



        private async void Btnguardar_clicked(object sender, EventArgs e)

        {
            await Navigation.PopAsync();
            await insertar_enfermos();
        }
        private async Task insertar_enfermos()

        {
            vmenfermo funcion = new vmenfermo();
            menfermos parametros = new menfermos();
            parametros.apellido = txtapellido.Text;
            parametros.direccion = txtdireccion.Text;
            parametros.fecha_nac = txtfecha_nac.Text;
            parametros.inscripcion = txtinscripcion.Text;
      
            await funcion.Insertar_enfermos(parametros);
            await DisplayAlert("listo", "Paciente agregado", "ok");
        }

        private async Task mostrar_enfermos()

        {
            vmenfermo funcion = new vmenfermo();
            var dt = await funcion.mostrar_enfermos();
        }
    }

}
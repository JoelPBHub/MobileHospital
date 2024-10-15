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
    public partial class ocupacion : ContentPage
    {
        public ocupacion()
        {
            InitializeComponent();
        }

        private async void Btnguardar_clicked(object sender, EventArgs e)

        {
            await Navigation.PopAsync();
            await insertar_ocupacion();
        }
        private async Task insertar_ocupacion()

        {
            vmocupacion funcion = new vmocupacion();
            mocupacion parametros = new mocupacion();
            parametros.cama = txtcama.Text;
            parametros.inscripcion = txtinscripcion.Text;
            parametros.sala_cod = txtsala_cod.Text;
            parametros.hospital_cod = txthospital_cod.Text;
            await funcion.insertar_ocupacion(parametros);
            await DisplayAlert("listo", "Paciente agregado", "ok");
        }

        private async Task mostrar_ocupacion()

        {
            vmocupacion funcion = new vmocupacion();
            var dt = await funcion.mostrar_ocupacion();
        }
    }

}


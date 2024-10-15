using Hospital.modelo;
using Hospital.vistamodelo;
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
    public partial class sala : ContentPage
    {
        public sala()
        {
            InitializeComponent();
        }


        private async void Btnguardar_clicked(object sender, EventArgs e)

        {
            await Navigation.PopAsync();
            await insertar_sala();
        }
        private async Task insertar_sala()

        {
            vmsala funcion = new vmsala();
            msala parametros = new msala();
            parametros.nombre = txtnombre.Text;
            parametros.sala_cod = txtsala_cod.Text;
            parametros.hospital_cod = txthospital_cod.Text;
            parametros.num_cama = txtnum_cama.Text;
            await funcion.insertar_sala(parametros);
            await DisplayAlert("listo", "Paciente agregado", "ok");
        }

        private async Task mostrar_sala()

        {
            vmsala funcion = new vmsala();
            var dt = await funcion.mostrar_sala();
        }
    }

}
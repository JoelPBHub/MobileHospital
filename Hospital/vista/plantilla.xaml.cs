using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.modelo;
using Hospital.vista;
using Hospital.vistamodelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class plantilla : ContentPage
    {
        public plantilla()
        {
            InitializeComponent();
        }
        private async void Btnguardar_clicked(object sender, EventArgs e)

        {
            await Navigation.PopAsync();
            await insertar_plantilla();
        }
        private async Task insertar_plantilla()

        {
            vmplantilla funcion = new vmplantilla();
            mplantilla parametros = new mplantilla();
            parametros.apellido = txtapellido.Text;
            parametros.empleado_no = txtempleado_no.Text;
            parametros.funcion = txtfuncion.Text;
            parametros.hospital_cod = txthospital_cod.Text;
            parametros.sala_cod = txtsala_cod.Text;
            parametros.salario = txtsalario.Text;
            parametros.turno = txtturno.Text;
            await funcion.insertar_plantilla(parametros);
            await DisplayAlert("listo", "Paciente agregado", "ok");
        }

        private async Task mostrar_plantilla()

        {
            vmplantilla funcion = new vmplantilla();
            var dt = await funcion.mostrar_plantilla();
        }
    }

}
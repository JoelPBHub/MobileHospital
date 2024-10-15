using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.vista.ResumenHospital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrimerosPasos : ContentPage
    {
        public PrimerosPasos()
        {
            InitializeComponent();
        }

        private void BtnOmitir_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginSession());
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Hospital.vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : Xamarin.Forms.TabbedPage
    {
        public Menu()
        {
            InitializeComponent();
            
        }
    }
}
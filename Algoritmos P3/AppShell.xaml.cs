using Algoritmos_P3.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Algoritmos_P3
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CotizacionesResultadosPage),
                typeof(CotizacionesResultadosPage));
            Routing.RegisterRoute(nameof(EstacionamientoResultadosPage), 
                typeof(EstacionamientoResultadosPage));
        }

    }
}

using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Algoritmos_P3.ViewModels
{
    [QueryProperty(nameof(Cambio),nameof(Cambio)),
        QueryProperty(nameof(Divisa10),nameof(Divisa10)),
        QueryProperty(nameof(Divisa5),nameof(Divisa5)),
        QueryProperty(nameof(Divisa2),nameof(Divisa2)),
        QueryProperty(nameof(Divisa1),nameof(Divisa1))]
    internal class EstacionamientoResultadosPageViewModel : ObservableObject
    {
        public EstacionamientoResultadosPageViewModel()
        {

        }

        string cambio;
        public string Cambio
        {
            get => cambio;
            set => SetProperty(ref cambio, value);
        }

        string divisa10;
        public string Divisa10
        {
            get => divisa10;
            set => SetProperty(ref divisa10, value);
        }

        string divisa5;
        public string Divisa5
        {
            get => divisa5;
            set => SetProperty(ref divisa5, value);
        }

        string divisa2;
        public string Divisa2
        {
            get => divisa2;
            set => SetProperty(ref divisa2, value);
        }

        string divisa1;
        public string Divisa1
        {
            get => divisa1;
            set => SetProperty(ref divisa1, value);
        }
    }
}

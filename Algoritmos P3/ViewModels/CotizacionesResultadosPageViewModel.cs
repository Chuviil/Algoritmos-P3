using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Algoritmos_P3.ViewModels
{
    [QueryProperty(nameof(CotCara),nameof(CotCara)),
        QueryProperty(nameof(CotBarata), nameof(CotBarata)),
        QueryProperty(nameof(PrmCots),nameof(PrmCots))]
    internal class CotizacionesResultadosPageViewModel : ObservableObject
    {
        public CotizacionesResultadosPageViewModel()
        {
            GoBack = new AsyncCommand(GoBackTask);
        }

        string cotCara = "Mas Cara: ";
        public string CotCara
        { 
            get => cotCara;
            set => SetProperty(ref cotCara, value); 
        }

        string cotBarata = "Mas Barata: ";
        public string CotBarata
        {
            get => cotBarata;
            set => SetProperty(ref cotBarata, value);
        }

        string prmCots = "Promedio: ";
        public string PrmCots
        {
            get => prmCots;
            set => SetProperty(ref prmCots, value);
        }

        public ICommand GoBack { get; }

        async Task GoBackTask()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

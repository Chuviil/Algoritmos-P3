using Algoritmos_P3.Views;
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
    internal class CotizacionesPageViewModel : ObservableObject
    {
        public CotizacionesPageViewModel()
        {
            CotsCalcular = new AsyncCommand(CalcularCots);
        }

        string cot1Display;
        public string Cot1Display
        {
            get => cot1Display;
            set => SetProperty(ref cot1Display, value);
        }

        string cot2Display;
        public string Cot2Display
        {
            get => cot2Display;
            set => SetProperty(ref cot2Display, value);
        }

        string cot3Display;
        public string Cot3Display
        {
            get => cot3Display;
            set => SetProperty(ref cot3Display, value);
        }

        string cot4Display;
        public string Cot4Display
        {
            get => cot4Display;
            set => SetProperty(ref cot4Display, value);
        }

        string cot5Display;
        public string Cot5Display
        {
            get => cot5Display;
            set => SetProperty(ref cot5Display, value);
        }

        string cotCara;
        public string CotCara
        {
            get => cotCara;
            set => SetProperty(ref cotCara, value);
        }

        string cotBarata;
        public string CotBarata
        {
            get => cotBarata;
            set => SetProperty(ref cotBarata, value);
        }

        string prmCots;
        public string PrmCots
        {
            get => prmCots;
            set => SetProperty(ref prmCots, value);
        }

        void CalcularTodo()
        {
                double[] cotizaciones = {Convert.ToDouble(cot1Display),Convert.ToDouble(cot2Display),
                Convert.ToDouble(cot3Display),Convert.ToDouble(cot4Display),
                Convert.ToDouble(cot5Display)};

                int i, j;
                double tmp;

                for (i = 0; i < 5; i++)
                {
                    for (j = i + 1; j < 5; j++)
                    {
                        if (cotizaciones[j] < cotizaciones[i])
                        {
                            tmp = cotizaciones[i];
                            cotizaciones[i] = cotizaciones[j];
                            cotizaciones[j] = tmp;
                        }
                    }
                }

                CotBarata = $"Mas Barata: {cotizaciones[0]} $";
                CotCara = $"Mas Cara: {cotizaciones[4]} $";
                PrmCots = $"Promedio: {(cotizaciones[1] + cotizaciones[2] + cotizaciones[3]) / 3} $";
        }

        public ICommand CotsCalcular { get; }

        async Task CalcularCots()
        {
            if (!String.IsNullOrEmpty(cot1Display) & !String.IsNullOrEmpty(cot2Display)
                & !String.IsNullOrEmpty(cot3Display) & !String.IsNullOrEmpty(cot4Display)
                & !String.IsNullOrEmpty(cot4Display))
            {
                CalcularTodo();
                var route = $"{nameof(CotizacionesResultadosPage)}?CotCara={CotCara}&CotBarata={CotBarata}&PrmCots={PrmCots}";
                await Shell.Current.GoToAsync(route);
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Valor(es) Incorrectos", "OK");
            }
                
        }

    }
}

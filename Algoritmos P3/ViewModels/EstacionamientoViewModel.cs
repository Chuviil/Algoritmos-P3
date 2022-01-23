using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Algoritmos_P3.Views;

namespace Algoritmos_P3.ViewModels
{
    internal class EstacionamientoViewModel : ObservableObject
    {
        public EstacionamientoViewModel()
        {
            EstacionamientoCalcular = new AsyncCommand(CalcularCostos); 
        }

        string horas;

        public string Horas
        {
            get => horas;
            set
            {
                horas = value;
                if (!string.IsNullOrEmpty(Horas))
                    CobroTotal = Convert.ToString(Convert.ToInt32(horas) * 30);
                else
                    CobroTotal = "0";
                OnPropertyChanged();
            }
        }

        string cobroTotal = "0";

        public string CobroTotal
        {
            get => cobroTotal;
            set => SetProperty(ref cobroTotal, value);
        }

        string pagoCliente;

        public string PagoCliente
        {
            get => pagoCliente;
            set => SetProperty(ref pagoCliente, value);
        }

        string monedasEntregadas;
        public string MonedasEntregadas
        {
            get => monedasEntregadas;
            set => SetProperty(ref monedasEntregadas, value);
        }

        public ICommand EstacionamientoCalcular { get; }

        async Task CalcularCostos()
        {
            if (!string.IsNullOrEmpty(Horas) & !string.IsNullOrEmpty(PagoCliente))
            {
                if (Convert.ToInt32(PagoCliente) >= Convert.ToInt32(CobroTotal))
                {
                    if (Convert.ToInt32(PagoCliente) == Convert.ToInt32(CobroTotal))
                    {
                        await Shell.Current.DisplayAlert("Pagado", "Se pago la cantidad exacta no hay cambio", "OK");
                        return;
                    }
                    int Cambio = Convert.ToInt32(PagoCliente) - Convert.ToInt32(CobroTotal);
                    int Divisa10, Divisa5, Divisa2, Divisa1;
                    Divisa10 = Cambio / 10;
                    Divisa5 = Cambio - (Divisa10 * 10);
                    Divisa5 = Divisa5 / 5;
                    Divisa2 = Cambio - ((Divisa10 * 10) + (Divisa5 * 5));
                    Divisa2 = Divisa2 / 2;
                    Divisa1 = Cambio - ((Divisa10*10)+(Divisa5*5)+(Divisa2*2));
                    MonedasEntregadas = Convert.ToString(Divisa10 + Divisa5 + Divisa2 + Divisa1);
                    var route = $"{nameof(EstacionamientoResultadosPage)}?Cambio={Cambio}&Divisa10={Divisa10}&Divisa5={Divisa5}&Divisa2={Divisa2}&Divisa1={Divisa1}&MonedasEntregadas={MonedasEntregadas}";
                    await Shell.Current.GoToAsync(route);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error!", "Valor(es) Incorrectos", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Rellene todos los campos", "OK");
            }
            
        }
    }
}

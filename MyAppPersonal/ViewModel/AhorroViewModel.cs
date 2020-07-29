using Java.Sql;
using MyAppPersonal.METODOS;
using MyAppPersonal.Models;
using MyAppPersonal.WebService;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace MyAppPersonal.ViewModel
{
    public class AhorroViewModel:BaseViewModel
    {
        public Ahorro Ahorro { get; set; }
        public Command cmdSave { get; set; }
        RepositoryWS<Ahorro> ws;
        public AhorroViewModel()
        {

        }
        public AhorroViewModel(Ahorro ahorro)
        {
            Ahorro = ahorro;
            if (Ahorro.Id==0)
            {
                Ahorro.fecha_termina_reto = DateTime.Now.AddYears(1);//por default le dejamos un año
            }
            cmdSave = new Command(save);
        }

        private async void save()
        {
            if (IsBusy == false)
            {
                IsBusy = true;
                ws = new RepositoryWS<Ahorro>();
                ws.urlWebService = new UrlServer().Server + "API/APIAhorro";
                DateTime DateStar = DateTime.Now;
                TimeSpan difFechas =Ahorro.fecha_termina_reto- DateStar;
                int cuantosDiasHayEnRagoFechas = difFechas.Days;
                
                if (cuantosDiasHayEnRagoFechas >= 7)
                {
                    Ahorro.noDia_aportar = cuantosDiasHayEnRagoFechas / 7;
                }

                Ahorro=await ws.SAVE(Ahorro);                
                IsBusy = false;
                if (ws.Error == null)
                {
                    List<Ahorro_aportaciones_programadas>LstAportacionesProgramadas=new reto_ahorro().algoridmo_reto_ahorro(DateStar, Ahorro);
                    aportaciones_programadas wsAProgramado = new aportaciones_programadas();
                    wsAProgramado.urlWebService = new UrlServer().Server + "API/APIAhorroAportacionesProgramadas";
                    await wsAProgramado.SAVE(LstAportacionesProgramadas);
                    if (wsAProgramado.Error==null)
                    {
                        //await Application.Current.MainPage.Navigation.PushAsync(new MemorizarTabbedPage(Memorizar.UsrCreoId));
                        await Application.Current.MainPage.DisplayAlert("Exito","Dato guardado", "Ok");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", wsAProgramado.Error, "Ok");
                    }

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ws.Error, "Ok");
                }
            }
        }
    }
}

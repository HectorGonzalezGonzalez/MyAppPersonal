using MyAppPersonal.Models;
using MyAppPersonal.View;
using MyAppPersonal.WebService;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyAppPersonal.ViewModel
{
    public class MemorizarViewModel:BaseViewModel
    {
        public Memorizar Memorizar { get; set; }
        public Command comandSavePalabra { get; set; }
        public Command commandDelete { get; set; }
        RepositoryWS<Memorizar> ws;
        public MemorizarViewModel()
        {

        }
        public MemorizarViewModel(Memorizar memorizar)
        {
            Memorizar = memorizar;
            comandSavePalabra = new Command(Save);
            commandDelete = new Command(Delete);
        }
        public async void Save()
        {
            if (IsBusy==false)
            {
                IsBusy = true;
                ws = new RepositoryWS<Memorizar>();
                ws.urlWebService = new UrlServer().Server + "API/APIMemorizar";
                if (Memorizar.Id==0)
                {
                    Memorizar.Estatus = 1;
                }
                await ws.SAVE(Memorizar);            
                await PopupNavigation.Instance.PopAllAsync(true);
                IsBusy = false;
                if (ws.Error==null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new MemorizarTabbedPage(Memorizar.UsrCreoId));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ws.Error, "Ok");
                }            
            }
        }
        public async void Delete()
        {
            if (IsBusy==false)
            {
                IsBusy = true;
                ws = new RepositoryWS<Memorizar>();
                ws.urlWebService = new UrlServer().Server + "API/APIMemorizar";
                Boolean respuesta=await ws.Delete(Memorizar.Id);
                await PopupNavigation.Instance.PopAllAsync(true);
                IsBusy = false;
                if (respuesta)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new LstMemorizarPage(Memorizar.UsrCreoId));
                }
            }
        }
    }
}

using Java.Nio.Channels;
using MyAppPersonal.Models;
using MyAppPersonal.View;
using MyAppPersonal.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyAppPersonal.ViewModel
{
    public class LstMemorizarViewModel : BaseViewModel
    {
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        private int totalRow;

        public int TotalRow
        {
            get { return totalRow; }
            set { 
                totalRow = value;
                OnPropertyChanged();
            }
        }



        private int currentPosition;

        public int CurrentPosition
        {
            get { return currentPosition; }
            set { 
                currentPosition = value;
                OnPropertyChanged();
                OnPropertyChanged("Paginacion");
            }
        }
        private string paginacion;

        public string Paginacion
        {
            get { 
                return $"{CurrentPosition} de {TotalRow}"; ; }
            
        }



        private Boolean mostrarMensajeRow;
        public Boolean MostrarMensajeRow
        {
            get { return mostrarMensajeRow; }
            set { 
                mostrarMensajeRow = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Memorizar> lstMemorizar;
        public ObservableCollection<Memorizar> LstMemorizar
        {
            get { return lstMemorizar; }
            set
            {
                lstMemorizar = value;
                OnPropertyChanged();                
            }
        }        

        RepositoryWS<Memorizar> ws;
        public LstMemorizarViewModel(int usrid)
        {
            MostrarMensajeRow = false;
            LlenarLista(usrid);            
        }
        private void PositionChanged(int position)
        {
            CurrentPosition = position;
            
        }

        public async void LlenarLista(int usrid)
        {
            if (IsBusy==false)
            {
                IsBusy = true;
                ws = new RepositoryWS<Memorizar>();
                ws.urlWebService = new UrlServer().Server + "API/APIMemorizar?UsrId="+usrid;
                LstMemorizar = await ws.GET();
                if (LstMemorizar.Count==0)
                {
                    MostrarMensajeRow = true;
                }
                TotalRow = LstMemorizar.Count;
                OnPropertyChanged("Paginacion");
                IsBusy = false;
            }
        }
        
        


    
    }
}

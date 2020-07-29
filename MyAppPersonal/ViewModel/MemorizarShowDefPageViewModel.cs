using MyAppPersonal.Models;
using MyAppPersonal.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MyAppPersonal.ViewModel
{
    public class MemorizarShowDefPageViewModel:BaseViewModel
    {
        public Command commandNext { get; set; }
        public Command commandBack { get; set; }


        private Boolean switchVisible;

        public Boolean SwitchVisible
        {
            get { return switchVisible; }
            set { 
                switchVisible = value;
                OnPropertyChanged();
            }
        }


        private Boolean visibleBtnBack;
        public Boolean VisibleBtnBack
        {
            get { return visibleBtnBack; }
            set { 
                visibleBtnBack = value;
                OnPropertyChanged();
            }
        }



        private Boolean visibleBtnNex;
        public Boolean VisibleBtnNex
        {
            get { return visibleBtnNex; }
            set {
                visibleBtnNex = value;
                OnPropertyChanged();
            }
        }



        private string pieDePagina;
        public string PieDePagina
        {
            get {
               return pieDePagina= $"{NoRowActual}  De {NoRow}";                
            }            
        }


        private int noRow;
        public int NoRow
        {
            get { return noRow; }
            set {
                noRow = value;
                OnPropertyChanged();
            }
        }
        private int noRowActual;

        public int NoRowActual
        {
            get { return noRowActual; }
            set { 
                noRowActual = value;
                OnPropertyChanged();
            }
        }



        private Memorizar memorizar;
        public Memorizar Memorizar
        {
            get { return memorizar; }
            set { 
                memorizar = value;
                OnPropertyChanged();
            }
        }
        

        public ObservableCollection<Memorizar> LstMemorizar { get; set; }
        public MemorizarShowDefPageViewModel()
        {

        }
        public MemorizarShowDefPageViewModel(int usrid)
        {
            VisibleBtnBack = false;
            visibleBtnNex = true;
            SwitchVisible = false;
            commandNext = new Command(nextPalabra);
            commandBack = new Command(backPalabra);
            NoRowActual = 0;
            LlenarLista(usrid);
            
        }
        public void backPalabra()
        {
            SwitchVisible = false;
            if (NoRowActual == NoRow)
            {
                VisibleBtnNex = true;
            }
            if (NoRowActual>0)
            {
                NoRowActual -= 1;
                Memorizar = LstMemorizar[NoRowActual];
                OnPropertyChanged("PieDePagina");
                if (NoRowActual==0)
                {
                    VisibleBtnBack = false;
                }
            }            
        }
        public void nextPalabra()
        {
            SwitchVisible = false;
            if (NoRowActual < NoRow)
            {
                NoRowActual += 1;
                Memorizar = LstMemorizar[NoRowActual];
                OnPropertyChanged("PieDePagina");
                VisibleBtnBack = true;
                if (NoRowActual==NoRow)
                {
                    VisibleBtnNex = false;
                }
            }            
        }
        public async void LlenarLista(int usrid)
        {
            RepositoryWS<Memorizar> ws = new RepositoryWS<Memorizar>();
            ws.urlWebService = new UrlServer().Server + "API/APIMemorizar?UsrId=" + usrid;
            LstMemorizar = await ws.GET();
            NoRow = LstMemorizar.Count;
            if (NoRow > 0)
            {
                NoRow = NoRow - 1;
                Memorizar = LstMemorizar[NoRowActual];
                OnPropertyChanged("PieDePagina");
            }
        }
        

    }
}

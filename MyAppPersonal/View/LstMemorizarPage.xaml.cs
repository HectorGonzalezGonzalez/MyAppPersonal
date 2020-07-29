using MyAppPersonal.Models;
using MyAppPersonal.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAppPersonal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LstMemorizarPage : ContentPage
    {
        int usrid = 0;
        public LstMemorizarPage(int usrid)
        {
            InitializeComponent();
            this.usrid = usrid;
            BindingContext = new LstMemorizarViewModel(usrid);
        }


        //protected override void OnAppearing()//para que se ejecute cuando se muestra la pantalla ya que cuando usamos => await Navigation.PopAsync();
        //{
        //    base.OnAppearing();
            
        //}

        private void LstMemorizar_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                Memorizar m = e.SelectedItem as Memorizar;
                PopupNavigation.Instance.PushAsync(new MemorizarPopupView(m));
            }                  
            ((ListView)sender).SelectedItem = null;//Limpiamos el item seleccionado para que nos permita seleccionar el mismo elemento si lo acabamos de seleccionar
        }

        

        private async void ViewCell_Appearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.TranslationX = -100;
            view.Opacity = 0;
            await Task.WhenAny<bool>(
                view.TranslateTo(0, 0, 250, Easing.SinIn),
                view.FadeTo(1, 500, Easing.BounceIn)
                );
            
        }
    }
}
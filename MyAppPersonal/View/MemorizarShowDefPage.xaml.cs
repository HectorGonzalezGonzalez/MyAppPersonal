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
    public partial class MemorizarShowDefPage : ContentPage
    {
        int usrid = 0;

        public MemorizarShowDefPage(int usrid)
        {
            InitializeComponent();
            BindingContext = new MemorizarShowDefPageViewModel(usrid);
            this.usrid = usrid;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Boolean switchSelect = e.Value;
            if (switchSelect)
            {
                lblDefinicion.IsVisible = true;
            }
            else
            {
                lblDefinicion.IsVisible = false;
            }

        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Memorizar m = new Memorizar();
            m.UsrCreoId = usrid;
            PopupNavigation.Instance.PushAsync(new MemorizarPopupView(m));
        }
    }
}
using MyAppPersonal.Models;
using MyAppPersonal.ViewModel;
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
    public partial class MemorizarCarruselPage : ContentPage
    {
        public MemorizarCarruselPage()
        {

        }
        public MemorizarCarruselPage(int usrid)
        {
            InitializeComponent();
            BindingContext = new LstMemorizarViewModel(usrid);            

        }        
    }
}
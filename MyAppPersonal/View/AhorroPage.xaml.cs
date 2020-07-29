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
    public partial class AhorroPage : ContentPage
    {
        public AhorroPage(Ahorro ahorro)
        {
            InitializeComponent();
            BindingContext = new AhorroViewModel(ahorro);
        }
    }
}
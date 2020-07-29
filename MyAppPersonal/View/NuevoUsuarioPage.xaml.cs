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
    public partial class NuevoUsuarioPage : ContentPage
    {
        public NuevoUsuarioPage()
        {
            InitializeComponent();
            UsuariosViewModel model = new UsuariosViewModel();
            BindingContext = model;
        }
    }
}
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
    public partial class MemorizarPopupView
    {
        public MemorizarPopupView(Memorizar memorizar)
        {
            InitializeComponent();
            BindingContext = new MemorizarViewModel(memorizar);
            if (memorizar.Id>0)
            {
                btnSave.Text = "ACTUALIZAR";
                titlePrincipal.Text = "Actualizar Palabra";
                btnDelete.IsVisible = true;
            }
        }

    }
}
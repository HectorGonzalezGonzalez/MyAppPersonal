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
    public partial class MemorizarTabbedPage : TabbedPage
    {
        public MemorizarTabbedPage(int usrid)
        {
            InitializeComponent();
            Children.Add(new MemorizarShowDefPage(usrid));
            Children.Add(new LstMemorizarPage(usrid));
            //Children.Add(new MemorizarCarruselPage(usrid));

        }
    }
}
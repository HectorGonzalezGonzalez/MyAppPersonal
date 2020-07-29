using MyAppPersonal.Models;
using MyAppPersonal.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAppPersonal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var a = new Ahorro();
            a.UsrCreoId = 5;
            var pagina = new NavigationPage(new AhorroPage(a));
            //var pagina = new NavigationPage(new MemorizarShowDefPage(5));
            //var pagina = new NavigationPage(new LstMemorizarPage(5));
            //var pagina = new NavigationPage(new LoginPage());
            pagina.BarBackgroundColor = (Color)App.Current.Resources["Azul"];//Color de la barrra
            pagina.BarTextColor = Color.White;
            MainPage = pagina;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

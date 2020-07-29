using Android.Content.Res;
using MyAppPersonal.Models;
using MyAppPersonal.View;
using MyAppPersonal.WebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyAppPersonal.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public Command cmdIniciarSession { get; set; }
        public Command cmdCrearCuenta { get; set; }
        public LoginViewModel()
        {
            NombreDeUsuario = "test";
            Password = "1234";
            cmdIniciarSession = new Command(IniciarSession);
            cmdCrearCuenta = new Command(CrearCuenta);
        }

        private void CrearCuenta()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NuevoUsuarioPage());
        }

        private async void IniciarSession()
        {
            if (IsBusy==false)
            {
                IsBusy = true;
                Login log = new Login();
                log.urlWebService = new UrlServer().Server + "API/APIUsuarios";
                int usrid=await log.validaLogin(NombreDeUsuario, Password);
                IsBusy = false;
                if (usrid > 0)
                {                
                    await Application.Current.MainPage.Navigation.PushAsync(new MemorizarTabbedPage(usrid));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error","Usuario o contraseña incorrecto", "Ok");
                }            
            }
        }

        public string NombreDeUsuario { get; set; }
        public string Password { get; set; }
    }
}

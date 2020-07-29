using MyAppPersonal.Models;
using MyAppPersonal.View;
using MyAppPersonal.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MyAppPersonal.ViewModel
{
   public class UsuariosViewModel: BaseViewModel
    {
        public Command cmdCrearUsuario { get; set; }
        public Usuario usuario { get; set; }
        public UsuariosViewModel()
        {
            usuario = new Usuario()
            {
                Nombre = "Hector",
                Paterno = "Glez",
                Materno = "Glez2",
                NombreDeUsuario = "Hgonzalez",
                Password = "1234",
                Estatus = true
            };            
            cmdCrearUsuario = new Command(CrearUsuario);
        }

        

        public async void CrearUsuario()
        {
            if (IsBusy==false)
            {
                IsBusy = true;
                if (string.IsNullOrEmpty(usuario.Nombre))
                {
                    await Application.Current.MainPage.DisplayAlert("Dato requerido", "El Nombre es requerido", "Ok");
                }
                else if (string.IsNullOrEmpty(usuario.Paterno))
                {
                    await Application.Current.MainPage.DisplayAlert("Dato requerido", "El Apellido Paterno es requerido", "Ok");
                }
                else if (string.IsNullOrEmpty(usuario.Materno))
                {
                    await Application.Current.MainPage.DisplayAlert("Dato requerido", "El Apellido Materno es requerido", "Ok");
                }
                else if (string.IsNullOrEmpty(usuario.NombreDeUsuario))
                {
                    await Application.Current.MainPage.DisplayAlert("Dato requerido", "El Nombre De Usuario es requerido", "Ok");
                }
                else if (string.IsNullOrEmpty(usuario.Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Dato requerido", "La contraseña es requerido", "Ok");
                }
                else
                {
                    RepositoryWS<Usuario> ws=new RepositoryWS<Usuario>();
                    ws.urlWebService = new UrlServer().Server + "API/APIUsuarios";
                    Usuario respuesta=await ws.SAVE(usuario);
                    if (respuesta!=null)
                    {
                        IsBusy = false;
                        //await Application.Current.MainPage.DisplayAlert("Exito", "Dato Guardado", "Ok");
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", ws.Error, "Ok");
                    }
                }
                IsBusy = false;
            }
        }
        
        
    }
}

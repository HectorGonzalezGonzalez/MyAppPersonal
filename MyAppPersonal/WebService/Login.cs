using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAppPersonal.WebService
{
    public class Login
    {
        public string urlWebService { get; set; }
        HttpClient clientHttp;
        public string Error { get; set; }
        public Login()
        {
            clientHttp = new HttpClient();
        }
        public async Task<int> validaLogin(string NombreDeUsuario, string Password)
        {
            int respuesta =0;
            Uri uri = new Uri(string.Format(urlWebService + "?NombreDeUsuario={0}&Password={1}", NombreDeUsuario, Password));
            HttpResponseMessage response = await clientHttp.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                respuesta = JsonConvert.DeserializeObject<int>(content);
            }            
            return respuesta;
        }
    }
}

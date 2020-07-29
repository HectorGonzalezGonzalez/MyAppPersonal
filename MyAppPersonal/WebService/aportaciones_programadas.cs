using MyAppPersonal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAppPersonal.WebService
{
    public class aportaciones_programadas
    {
        public string urlWebService { get; set; }
        HttpClient clientHttp;
        public string Error { get; set; }        
        public aportaciones_programadas()
        {
            clientHttp = new HttpClient();
        }
        public async Task<List<Ahorro_aportaciones_programadas>> SAVE(List<Ahorro_aportaciones_programadas> LstAportacionesProgramadas)
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(urlWebService);
                string json = JsonConvert.SerializeObject(LstAportacionesProgramadas);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (LstAportacionesProgramadas.Count>0)
                {
                    response = await client.PostAsync(uri, content);
                }
                List<Ahorro_aportaciones_programadas> respuesta = null;
                if (response.IsSuccessStatusCode)
                {
                    var resultStriong = response.Content.ReadAsStringAsync().Result;
                    respuesta = JsonConvert.DeserializeObject<List<Ahorro_aportaciones_programadas>>(resultStriong);
                }
                else
                {
                    var resultStriong = response.Content.ReadAsStringAsync().Result;
                    Error = JsonConvert.DeserializeObject<HttpError>(resultStriong).Message;
                }
                return respuesta;
            }
        }
    }
}

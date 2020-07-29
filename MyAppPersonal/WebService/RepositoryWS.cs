using MyAppPersonal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAppPersonal.WebService
{
    public class RepositoryWS<T>where T:BaseDTO
    {
        public string urlWebService { get; set; }        
        public string Error { get; set; }        
        public async Task<ObservableCollection<T>> GET()
        {
            ObservableCollection<T> Lst = null;
            using (var client=new HttpClient())
            {
                Uri uri = new Uri(urlWebService);
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Lst = JsonConvert.DeserializeObject<ObservableCollection<T>>(content);
                }
            }
           
            return Lst;
        }
        public async Task<T> SAVE(T entidad)
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(urlWebService);
                string json = JsonConvert.SerializeObject(entidad);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (entidad.Id==0)
                {                    
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                T respuesta = null;
                if (response.IsSuccessStatusCode)
                {
                    var resultStriong = response.Content.ReadAsStringAsync().Result;
                    respuesta = JsonConvert.DeserializeObject<T>(resultStriong);
                }
                else
                {
                    var resultStriong = response.Content.ReadAsStringAsync().Result;
                    Error = JsonConvert.DeserializeObject<HttpError>(resultStriong).Message;                                

                }
                return respuesta;
            }
        }
        public async Task<Boolean> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(urlWebService+"?id="+id);
                HttpResponseMessage response = await client.DeleteAsync(uri);
                Boolean respuesta = false;
                if (response.IsSuccessStatusCode)
                {
                    var resultStriong = response.Content.ReadAsStringAsync().Result;
                    respuesta = JsonConvert.DeserializeObject<Boolean>(resultStriong);
                }
                else{
                    respuesta = false;
                }
                return respuesta;
            }
        }
    }
    }

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EduAPP.Models;
using Newtonsoft.Json;

namespace EduAPP.Services
{
    public class InRestService : IRestServiceI<Inscription>
    {
        HttpClient _client;

        public List<Inscription> Inscriptions { get; private set; }

        public Inscription Inscription { get; private set; }

        public InRestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Inscription>> RefreshDataAsync()
        {
            Inscriptions = new List<Inscription>();

            var uri = new Uri(string.Format(Config.InscriptionUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Inscriptions = JsonConvert.DeserializeObject<List<Inscription>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Inscriptions;
        }

        public async Task SaveTodoInscriAsync(Inscription item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Config.InscriptionUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tInscription successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Config.InscriptionDelUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tInscription successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<Inscription> GetTodoItemByIdAsync(string id)
        {
            Inscription = new Inscription();

            var uri = new Uri(string.Format(Config.InscriptionUrl, id));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Inscription = JsonConvert.DeserializeObject<Inscription>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Inscription;
        }
    }
}

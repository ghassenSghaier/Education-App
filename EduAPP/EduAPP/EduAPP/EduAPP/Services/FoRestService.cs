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
    public class FoRestService : IRestService<Formation>
    {
        HttpClient _client;

        public List<Formation> Formations { get; private set; }
        public Formation Formation { get; private set; }

        public FoRestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Formation>> RefreshDataAsync()
        {
            Formations = new List<Formation>();

            var uri = new Uri(string.Format(Config.FormationUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Formations = JsonConvert.DeserializeObject<List<Formation>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Formations;
        }

        public async Task SaveTodoItemAsync(Formation item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Config.FormationUrl, string.Empty));

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
                    Debug.WriteLine(@"\tFormation successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        /*************************/

        public async Task SaveInscriAsync(Inscription item, bool isNewItem = false)
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
        /****************************/

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Config.FormationUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tFormation successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<Formation> GetTodoItemByIdAsync(string id)
        {
            Formation = new Formation();

            var uri = new Uri(string.Format(Config.FormationUrl, id));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Formation = JsonConvert.DeserializeObject<Formation>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Formation;
        }
    }
}

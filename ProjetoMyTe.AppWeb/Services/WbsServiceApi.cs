using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using ProjetoMyTe.AppWeb.Models;
using ProjetoMyTe.AppWeb.Models.Entities;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoMyTe.AppWeb.Services
{
    public class WbsServiceApi
    {
        private readonly HttpClient httpClient;
        private readonly WbssService wbssService;
        public WbsServiceApi(IHttpClientFactory client, WbssService wbssService)
        {
            httpClient = client.CreateClient();

            this.wbssService = wbssService;

            httpClient.BaseAddress = new Uri("http://localhost:5147/");
            httpClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<WbsClient>> ListarWbsAsync()
        {
            try
            {

                
                var response = await httpClient.GetAsync("api/wbss");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<WbsClient[]>();
                    return lista!.ToList();
                }
                else
                {
                    throw new Exception("Não foi possível obter a lista de wbs");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        

    }
}

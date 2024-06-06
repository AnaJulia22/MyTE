using Microsoft.CodeAnalysis.Elfie.Serialization;
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

            httpClient.BaseAddress = new Uri("https://myte-decola-api.azurewebsites.net/");
            httpClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<WbsClient>> ListarWbsAsync(string codigoWbs)
        {
            try
            {
                
                var response = await httpClient.GetAsync("api/wbss/{codigoWbs}");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<WbsClient[]>();
                    
                    if (codigoWbs == null)
                    {
                        return lista!.ToList();
                    }
                    else
                    {
                        return lista!.ToList().Where(c => c.codigoWbs == codigoWbs);
                    }
                    
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

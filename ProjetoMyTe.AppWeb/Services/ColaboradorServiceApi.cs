using ProjetoMyTe.AppWeb.Models;
using System.Net.Http.Headers;

namespace ProjetoMyTe.AppWeb.Services
{
    public class ColaboradorServiceApi
    {
        private readonly HttpClient httpClient;

        public ColaboradorServiceApi(IHttpClientFactory client)
        {
            httpClient = client.CreateClient();

            httpClient.BaseAddress = new Uri("http://localhost:5147/");
            httpClient.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<ColaboradorClient>> ListarColaboraresAsyn()
        {
            try
            {
                var response = await httpClient.GetAsync("api/colaboradores");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<ColaboradorClient[]>();
                    return lista!.ToList();
                }
                else
                {
                    throw new Exception("Não foi possível obter a lista de colaboradores");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

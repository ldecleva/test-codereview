using System.Text.Json;

namespace test_codereview.Infrastructure
{
    public class BancoProvinciaClient
    {
        private readonly HttpClient httpClient;

        public BancoProvinciaClient(HttpClient httpClient)
        {
            ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));
            this.httpClient = httpClient;
        }

        public List<string>? GetCotizacion()
        {
            var url = "https://www.bancoprovincia.com.ar/Principal/Dolar";

            var response = httpClient.GetAsync(url).Result;

            response.EnsureSuccessStatusCode();

            var responseStream = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<List<string>>(responseStream);
        }

    }
}
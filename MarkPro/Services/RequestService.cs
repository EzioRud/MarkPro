using MarkPro.Models;
using System.Text.Json;

namespace MarkPro.Services
{
    public class RequestService
    {
        private HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       /* public async Task<IEnumerable<Media>?> GetNumbers()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetMedia>(responseStream);
        }*/
    }
}

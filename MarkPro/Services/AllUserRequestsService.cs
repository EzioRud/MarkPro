using MarkPro.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MarkPro.Services
{
    public class AllUserRequestsService : IAllUserRequestsService
    {
        private HttpClient _httpClient;

        public AllUserRequestsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AllUserRequests>?> GetAllUserRequests(int UserID)
        {
            var response = await _httpClient.GetAsync($"http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/user/{UserID}/requests?take=100&skip=0");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<AllRequests>(responseStream);

            return responseObject?.results?.Select(i => new AllUserRequests
            {
                UserName = i.requestedBy.plexUsername,
                MediaName = i.media.externalServiceSlug,
                MediaStatus = i.media.status.ToString(),
                MediaType = i.media.mediaType
                
            });

        }
    }
}

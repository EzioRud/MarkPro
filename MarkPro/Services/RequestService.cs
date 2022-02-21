using MarkPro.Models;
using System.Text.Json;

namespace MarkPro.Services
{
    public class RequestService : IRequestService
    {
        private HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Request>?> GetRequests()
        {
            var response = await _httpClient.GetAsync("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/request/");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<ListRequests>(responseStream);

            return responseObject?.results.Select(request => new Request
            {
                Avatar = request.requestedBy.avatar,
                MediaName = "Media name: " + request.media.externalServiceSlug,
                RequestedBy = "Requested By: " + request.requestedBy.plexUsername,
                MediaType = "Media Type: " + request.media.mediaType
            }) ;
        }
    }
}

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
                MediaName = request.media.externalServiceSlug,
                RequestedBy = request.requestedBy.plexUsername,
                MediaType = request.media.mediaType,
                DateRequested = request.media.createdAt.ToString(),
                Status = request.media.status
                
            }) ;
        }
    }
}

using MarkPro.Models;
using System.Text.Json;

namespace MarkPro.Services
{
    public class TotalRequestService : ITotalRequestService
    {
        private HttpClient _httpClient;

        public TotalRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TotalRequestCount>?> TotalRequestss()
        {
            var response = await _httpClient.GetAsync("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/request/count");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<ParentRequests>(responseStream);

            return responseObject?.TotalRequests?.Select(request => new TotalRequestCount
            {
                PendingRequests = request.pending,
                AvailableRequests = request.available,
                ProcessingRequests = request.processing,
                ApprovedRequests = request.approved
            });
        }
    }
}

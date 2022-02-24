using MarkPro.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MarkPro.Services
{
    public class HistoryService : IHistoryService
    {
        private HttpClient _httpClient;
        public HistoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<MediaHistory>?> GetHistory()
        {

            var response = await _httpClient.GetAsync("?apikey=332585e9a336416fba06c72da3a3cb7d&cmd=get_history&take=100&skip=0");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<HistoryRoot>(responseStream);

            return responseObject?.response?.data.data.Select(i => new MediaHistory
            {
                MediaTitle = i.full_title,
                UserWatching = i.friendly_name,
                CompletionStatus = i.percent_complete + "%",
                WatchedStatus = i.watched_status,
                State = i.state
            });
        }
    }
}

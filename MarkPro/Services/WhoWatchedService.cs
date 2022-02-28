using MarkPro.Models;
using System.Net.Http.Headers;
using System.Text.Json;


namespace MarkPro.Services
{
    public class WhoWatchedService : IWhoWatchedService
    {
        private HttpClient _httpClient;
        private IHistoryService _historyService;
        public WhoWatchedService(HttpClient httpClient, IHistoryService historyService)
        {
            _httpClient = httpClient;
            _historyService = historyService;
        }


        public async Task<IEnumerable<User>?> GetAllWhoWatched(string RatingKey)
        {

            var response = await _httpClient.GetAsync($"?apikey=332585e9a336416fba06c72da3a3cb7d&cmd=get_item_user_stats&rating_key={RatingKey}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<WhoWatched>(responseStream);

            return responseObject?.response?.data?.Select(i => new User
            {
                Name = i.friendly_name,
                Id = i.user_id,
                TotalTime = i.total_time/60,
                TotalPlays = i.total_plays,
                
            });
        }
    }
}

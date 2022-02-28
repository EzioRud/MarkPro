using MarkPro.Models;

namespace MarkPro.Services
{
    public class TestService : ITestService
    {
        private HttpClient _httpClient;

        public TestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TestModel>?> TestHistory(string RatingKey)
        {
            var response = await _httpClient.GetAsync($"?apikey=332585e9a336416fba06c72da3a3cb7d&cmd=get_item_user_stats&rating_key={RatingKey}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await System.Text.Json.JsonSerializer.DeserializeAsync<HistoryRoot>(responseStream);

            return responseObject?.response?.data?.data.Select(i => new TestModel
            {
                Name = i.friendly_name,
                CompletionStatus = i.watched_status.ToString()
            });
        }
    }
}

using MarkPro.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MarkPro.Services
{
    public class GetUserService : IGetUserService
    {
        private HttpClient _httpClient;
        public GetUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>?> GetUsersList()
        {
            var response = await _httpClient.GetAsync("?apikey=332585e9a336416fba06c72da3a3cb7d&cmd=get_user_names");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetUsersList>(responseStream);

            return responseObject?.response?.data.Select(i => new User
            {
                Name = i.friendly_name,
                Id = i.user_id
            }); 
        }
    }
}

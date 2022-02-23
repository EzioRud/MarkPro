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
            /*var response = await _httpClient.GetAsync($"http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/user/");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<AllRequests>(responseStream);

            return responseObject?.results.Select(i => new User
            {
               Name = i.requestedBy.plexUsername,
               Id = i.requestedBy.id
            });*/
            var response = await _httpClient.GetAsync("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/user/?take=100&skip=0");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<MyUsers>(responseStream);

            var UserRequests = new ListRequests();
            var Users = new User();

            return responseObject?.results?.Select(i => new User
            {             
                Id = i.id,
                Name = i.plexUsername
            }); 
        }
    }
}

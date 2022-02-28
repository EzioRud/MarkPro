using MarkPro.Models;

namespace MarkPro.Services
{
    public interface IWhoWatchedService
    {
        Task<IEnumerable<User>?> GetAllWhoWatched(string RatingKey);
    }
}
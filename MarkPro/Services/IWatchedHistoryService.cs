using MarkPro.Models;

namespace MarkPro.Services
{
    public interface IWatchedHistoryService
    {
        Task<IEnumerable<MediaWatchedHistory>?> GetMediaHistory(string RatingKey);
    }
}
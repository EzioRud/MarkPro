using MarkPro.Models;

namespace MarkPro.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<MediaHistory>?> GetHistory();
    }
}
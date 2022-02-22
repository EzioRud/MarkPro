using MarkPro.Models;

namespace MarkPro.Services
{
    public interface ITotalRequestService
    {
        Task<IEnumerable<TotalRequestCount>?> TotalRequestss();
    }
}
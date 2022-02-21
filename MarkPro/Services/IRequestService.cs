using MarkPro.Models;

namespace MarkPro.Services
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>?> GetRequests();
    }
}
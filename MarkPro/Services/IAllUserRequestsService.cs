using MarkPro.Models;

namespace MarkPro.Services
{
    public interface IAllUserRequestsService
    {
        Task<IEnumerable<AllUserRequests>?> GetAllUserRequests(int UserID);
    }
}
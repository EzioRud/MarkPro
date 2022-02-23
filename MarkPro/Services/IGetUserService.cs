using MarkPro.Models;

namespace MarkPro.Services
{
    public interface IGetUserService
    {
        Task<IEnumerable<User?>> GetUsersList();
    }
}

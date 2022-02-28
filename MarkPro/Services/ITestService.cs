using MarkPro.Models;

namespace MarkPro.Services
{
    public interface ITestService
    {
        Task<IEnumerable<TestModel>?> TestHistory(string RatingKey);
    }
}
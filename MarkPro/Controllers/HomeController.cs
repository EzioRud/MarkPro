using MarkPro.Models;
using MarkPro.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarkPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetUserService _getUserService;
        private readonly IRequestService _requestService;
        private readonly ITotalRequestService _totalRequestService;
        private readonly IAllUserRequestsService _allUserRequestsService;
        private readonly IHistoryService _historyService;
        private readonly IWatchedHistoryService _watchedHistoryService;
        private readonly ITestService _testService;
        private readonly IWhoWatchedService _whoWatchedService;

        public HomeController(ILogger<HomeController> logger, IWhoWatchedService whoWatchedService ,ITestService testService, IWatchedHistoryService watchedHistoryService ,IHistoryService historyService, IGetUserService getUserService, IRequestService requestService, ITotalRequestService totalRequestService, IAllUserRequestsService allUserRequestsService)
        {
            _logger = logger;
            _getUserService = getUserService;   
            _requestService = requestService;
            _totalRequestService = totalRequestService;
            _allUserRequestsService = allUserRequestsService;
            _historyService = historyService;
            _watchedHistoryService = watchedHistoryService;
            _testService = testService;
            _whoWatchedService = whoWatchedService;
        }
        //Who watched
        public async Task<IActionResult> WhoWatchedMedia(string RatingKey)
        {
            var Users = await WhoWatched(RatingKey);

            return View(Users);
        }

        private async Task<IEnumerable<User>?> WhoWatched(string RatingKey)
        {
            try
            {
                var HistoryList = await _whoWatchedService.GetAllWhoWatched(RatingKey);
                return HistoryList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<User>();
            }
        }
        //end

        //test begins
        public async Task<IActionResult> MediaTest(string RatingKey)
        {
            var Users = await TestMedia(RatingKey);

            return View(Users);
        }

        private async Task<IEnumerable<TestModel>?> TestMedia(string RatingKey)
        {
            try
            {
                var HistoryList = await _testService.TestHistory(RatingKey);
                return HistoryList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<TestModel>();
            }
        }
        //end


        //Media History view
        public async Task<IActionResult> GetAllMediaHistory(string RatingKey)
        {
            var Users = await GetAllMedia(RatingKey);

            return View(Users);
        }

        private async Task<IEnumerable<MediaWatchedHistory>?> GetAllMedia(string RatingKey)
        {
            try
            {
                var HistoryList = await _watchedHistoryService.GetMediaHistory(RatingKey);
                return HistoryList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<MediaWatchedHistory>();
            }
        }
        //End

        //History view
        public async Task<IActionResult> History()
        {
            var Users = await GetUserHistory();

            return View(Users);
        }

        private async Task<IEnumerable<MediaHistory>?> GetUserHistory()
        {
            try
            {
                var HistoryList = await _historyService.GetHistory();
                return HistoryList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<MediaHistory>();
            }
        }
        //End

        //All users view
        public async Task<IActionResult> Index()
        {
            var Users = await UsersResults();
           
            return View(Users);
        }

        private async Task<IEnumerable<User?>> UsersResults()
        {
            try
            {
                var UsersList = await _getUserService.GetUsersList();
                return UsersList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<User>();
            }
        }
        //End

        //All User Requests View
        public async Task<IActionResult> AllUserRequestsView(int UserId)
        {
            var requests = await AllRequests(UserId);

            return View(requests);
        }

        private async Task<IEnumerable<AllUserRequests>?> AllRequests(int UserId)
        {
            try
            {
                var UsersList = await _allUserRequestsService.GetAllUserRequests(UserId);
                return UsersList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<AllUserRequests>();
            }
        }
        //End

        public async Task<IActionResult> Privacy()
        {
            var Requests = await RequestsResults();
            return View(Requests);
        }

        private async Task<IEnumerable<Request>> RequestsResults()
        {
            try
            {
                var RequestList = await _requestService.GetRequests();
                return RequestList;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<Request>();
            }
        }

        public async Task<IActionResult> UserRequests() 
        {
            var Requests = await RequestsResults();
            return View(Requests);

        }

        public async Task<IActionResult> TotalRequests() //total requests
        {
            var Requests = await TotalRequets();
            return View(Requests);
        }

        private async Task<IEnumerable<TotalRequestCount>?> TotalRequets()
        {
            try
            {
                var Requests = await _totalRequestService.TotalRequestss();
                return Requests;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<TotalRequestCount>();
            }
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
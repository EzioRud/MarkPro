﻿using MarkPro.Models;
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

        public HomeController(ILogger<HomeController> logger, IGetUserService getUserService, IRequestService requestService, ITotalRequestService totalRequestService)
        {
            _logger = logger;
            _getUserService = getUserService;   
            _requestService = requestService;
            _totalRequestService = totalRequestService;
        }

        public async Task<IActionResult> Index()
        {
            var Users = await UsersResults();
           
            return View(Users);
        }

        private async Task<IEnumerable<User>> UsersResults()
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

        private async Task<IEnumerable<TotalRequestCount>> TotalRequets()
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

        public async Task<IActionResult> TotalRequests() //total requests
        {
            var Requests = await TotalRequets();
            return View(Requests);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
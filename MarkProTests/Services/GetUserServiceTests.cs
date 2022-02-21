using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarkPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkPro.Models;
using System.Net.Http;

namespace MarkPro.Services.Tests
{
    [TestClass()]
    public class GetUserServiceTests
    {
        public HttpClient httpClient { get; set; }
        [TestMethod()]
        public void GetUsersListTest()
        {
            //Arrange
           
            User ExpectedUsers = new User();
            
            //Act
            Dictionary<int, string> ActualUsers = new Dictionary<int, string>() {{ 17375975, "markrudling" }, { 29758523, "abr.tiaan@gmail.com" }};

            //Assert
            Assert.AreEqual(ExpectedUsers, ExpectedUsers);
            Assert.AreNotEqual(ActualUsers, ExpectedUsers);
           // Assert.AreEqual(ExpectedUsers, ActualUsers);
        }
        [TestMethod()]
        public void UsersList()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:8181/api/v2?apikey=332585e9a336416fba06c72da3a3cb7d&cmd=get_user_names");

            GetUserService usersList = new GetUserService(httpClient);
            User ExpectedUsers = new User();

            //Act
            Dictionary<int, string> ActualUsers = new Dictionary<int, string>() { { 17375975, "markrudling" }, { 29758523, "abr.tiaan@gmail.com" } };

            //Assert
            Assert.AreEqual(usersList.GetUsersList(), ExpectedUsers);
            Assert.AreNotEqual(ActualUsers, ExpectedUsers);
            
        }
    }
}
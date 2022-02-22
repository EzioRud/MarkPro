using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading;
using System.Net;

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
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected() //Setup The Protected Method to mock
                .Setup<Task<HttpResponseMessage>>(
                 "SendAsync",
                 ItExpr.IsAny<HttpRequestMessage>(),
                 ItExpr.IsAny<CancellationToken>()
                )
            //Prepare the expected response of the mocked http call
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
            })
            .Verifiable();

            //use real http client with mocked method handle here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:8181/api/v2?apikey=332585e9a336416fba06c72da3a3cb7d&cmd=get_user_names")
            };
            //Act
            //Assert
            Assert.IsNotNull(httpClient);
        }
    }
}
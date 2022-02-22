using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;
using Moq.Protected;
using System.Threading;
using System.Net;
using System.Net.Http.Headers;

namespace MarkProTests.Services
{
    [TestClass()]
    public class RequestService
    {
        public HttpClient httpClient { get; set; }
        [TestMethod()]
        public void RequestServiceTests()
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
                BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/request/?x-api-key=MTY0MzA5MjU5Njk1NzIxYmRjZWZiLWIxYWMtNGI1NC1hYzAxLWFhYWJhZjZjOTE1MSk="),
            };
            //Act
            //Assert
            Assert.IsNotNull(httpClient);
        }
    }
}

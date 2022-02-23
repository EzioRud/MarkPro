using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;
using Moq;
using Moq.Protected;

namespace GetUserServic.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetUsersListTest()
        {
            var httRequest = new HttpRequestMessage();
            var cancellationToken = CancellationToken.None;
            //Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected() //Setup The Protected Method to mock
                .Setup<Task<HttpResponseMessage>>(
                 "SendAsync",
                 httRequest,
                 cancellationToken
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
            var result = await httpClient.SendAsync(httRequest, cancellationToken);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
    }
}
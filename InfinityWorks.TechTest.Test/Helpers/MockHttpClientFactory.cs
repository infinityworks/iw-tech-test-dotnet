using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Test.Helpers
{
    static class MockHttpClientFactory
    {
        public static Mock<IHttpClientFactory> GetMockHttpClientFactory(string content)
        {
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var messageHandlerMock =
                new MockHttpMessageHandler((request, cancellation) =>
                {
                    var responseMessage =
                        new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(content)
                        };

                    var result = Task.FromResult(responseMessage);
                    return result;
                });

            var httpClient = new HttpClient(messageHandlerMock);

            httpClientFactoryMock
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            return httpClientFactoryMock;
        }
    }
}

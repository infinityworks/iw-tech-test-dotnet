using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Test.Helpers
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _sendAsyncFunc;

        public MockHttpMessageHandler(
            Func<HttpRequestMessage, 
            CancellationToken, 
            Task<HttpResponseMessage>> sendAsyncFunc)
        {
            _sendAsyncFunc = sendAsyncFunc;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            return await _sendAsyncFunc.Invoke(request, cancellationToken);
        }
    }
}

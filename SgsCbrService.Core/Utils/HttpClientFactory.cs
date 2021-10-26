using System;
using System.Net.Http;
using SgsCbrService.Core.Interfaces;

namespace SgsCbrService.Core.Utils
{
    public class HttpClientFactory : IHttpClientFactory
    {
        /// <summary>
        /// Создать HttpClient с обработчиком SocketsHttpHandler
        /// </summary>
        public HttpClient CreateClient()
        {
            HttpMessageHandler handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(5)
            };

            return new HttpClient(handler);
        }
    }
}

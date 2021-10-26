using System.Net.Http;

namespace SgsCbrService.Core.Interfaces
{
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Создать HttpClient
        /// </summary>
        HttpClient CreateClient();
    }
}

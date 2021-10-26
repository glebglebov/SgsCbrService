using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SgsCbrService.Core.CBR.Responses;

namespace SgsCbrService.Core.CBR
{
    public class CbrClient
    {
        private const string BaseUrl = "https://www.cbr-xml-daily.ru";

        private readonly HttpClient _client;

        public CbrClient(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Получить данные о курсах валют
        /// </summary>
        public async Task<DailyCurrenciesResponse> GetActualDaily()
        {
            return await CallAsync<DailyCurrenciesResponse>("/daily_json.js");
        }

        /// <summary>
        /// Получить архивные данные о курсах валют
        /// </summary>
        public void GetArchivedDaily(int day, int month, int year)
        {

        }

        /// <summary>
        /// Вызвать метод API
        /// </summary>
        /// <typeparam name="T">Тип ответа</typeparam>
        /// <param name="path">путь запроса</param>
        /// <param name="params">параметры запроса</param>
        private async Task<T> CallAsync<T>(string path, Dictionary<string, string> @params = null)
        {
            string url = BaseUrl + path;

            if (@params != null)
            {
                string queryParameters = BuildHttpParams(@params);

                url += "?" + queryParameters;
            }

            var raw = await _client.GetStringAsync(url);

            try
            {
                var response = JsonConvert.DeserializeObject<T>(raw);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Собрать параметры запроса
        /// </summary>
        private string BuildHttpParams(Dictionary<string, string> @params)
        {
            string parameters = string.Join("&", 
                @params.Select(p => $"{p.Key}={p.Value}"));

            return parameters;
        }
    }
}

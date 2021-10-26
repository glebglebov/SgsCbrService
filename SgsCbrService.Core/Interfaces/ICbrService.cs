using System.Threading.Tasks;
using SgsCbrService.Core.WebApiResponses;

namespace SgsCbrService.Core.Interfaces
{
    public interface ICbrService
    {
        /// <summary>
        /// Получить данные о курсах валют на текущий день
        /// </summary>
        /// <param name="count">количество возвращаемых элементов</param>
        /// <param name="offset">смещение относительно начала</param>
        Task<Response> GetActualCurrencies(int count = 10, int offset = 0);

        /// <summary>
        /// Получить данные о курсе конкретной валюты
        /// </summary>
        /// <param name="id">идентификатор валюты</param>
        Task<Response> GetActualCurrency(string id);

        /// <summary>
        /// Получить данные о курсах валют по дате
        /// </summary>
        /// <param name="day">день месяца</param>
        /// <param name="month">порядковый номер месяца</param>
        /// <param name="year">год</param>
        Response GetCurrenciesByDate(int day, int month, int year);

        /// <summary>
        /// Получить данные о курсе конкретной валюты под дате
        /// </summary>
        /// <param name="id">идентификатор валюты</param>
        /// <param name="day">день месяца</param>
        /// <param name="month">порядковый номер месяц</param>
        /// <param name="year">год</param>
        Response GetCurrencyByDate(string id, int day, int month, int year);
    }
}

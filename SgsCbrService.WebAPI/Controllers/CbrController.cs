using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SgsCbrService.Core.Interfaces;
using SgsCbrService.Core.WebApiResponses;

namespace SgsCbrService.WebAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class CbrController : ControllerBase
    {
        private readonly ICbrService _cbrService;

        public CbrController(ICbrService cbrService)
        {
            _cbrService = cbrService;
        }

        [HttpGet("/currencies")]
        public async Task<Response> Get(int count = 100, int offset = 0)
        {
            if (count < 0 || offset < 0)
            {
                return new Response { IsOk = false };
            }

            return await _cbrService.GetActualCurrencies(count, offset);
        }

        [HttpGet("/currencies/{day}/{month}/{year}")]
        public async Task<Response> Get(int day, int month, int year)
        {
            return await _cbrService.GetCurrenciesByDate(day, month, year);
        }

        [HttpGet("/currency/{id}")]
        public async Task<Response> Get(string id)
        {
            if (id.Length < 3)
            {
                return new Response { IsOk = false };
            }

            return await _cbrService.GetActualCurrency(id);
        }
    }
}

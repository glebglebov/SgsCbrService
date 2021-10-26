using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SgsCbrService.Core.CBR;
using SgsCbrService.Core.CBR.Model;
using SgsCbrService.Core.DTO;
using SgsCbrService.Core.Interfaces;
using SgsCbrService.Core.Utils;
using SgsCbrService.Core.WebApiResponses;

namespace SgsCbrService.Core.Services
{
    public class CbrService : ICbrService
    {
        private CbrClient _client;

        public CbrService()
        {
            Initialize();
        }

        private void Initialize()
        {
            var factory = new HttpClientFactory();
            var httpClient = factory.CreateClient();

            _client = new CbrClient(httpClient);
        }

        public async Task<Response> GetActualCurrencies(int count = 100, int offset = 0)
        {
            var response = await _client.GetActualDaily();

            var valutes = response.Valutes
                .Skip(offset)
                .Take(count)
                .Select(v => v.Value);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Valute, CurrencyDto>());
            var mapper = new Mapper(config);

            var currencies = mapper.Map<List<CurrencyDto>>(valutes);

            return new GetCurrenciesResponse
            {
                IsOk = true,
                Date = response.Date,
                Currencies = currencies
            };
        }

        public async Task<Response> GetActualCurrency(string id)
        {
            string idUpper = id.ToUpper();

            var response = await _client.GetActualDaily();

            var valute = response.Valutes
                .FirstOrDefault(v => v.Value.Id == idUpper);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Valute, CurrencyDto>());
            var mapper = new Mapper(config);

            var currency = mapper.Map<CurrencyDto>(valute.Value);

            return new GetCurrencyResponse
            {
                IsOk = true,
                Date = response.Date,
                Currency = currency
            };
        }

        public Response GetCurrenciesByDate(int day, int month, int year)
        {
            throw new NotImplementedException();
        }

        public Response GetCurrencyByDate(string id, int day, int month, int year)
        {
            throw new NotImplementedException();
        }
    }
}

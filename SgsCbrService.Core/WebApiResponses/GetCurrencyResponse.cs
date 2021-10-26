using System;
using SgsCbrService.Core.DTO;

namespace SgsCbrService.Core.WebApiResponses
{
    public class GetCurrencyResponse : Response
    {
        public DateTime Date { get; set; }

        public CurrencyDto Currency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using SgsCbrService.Core.DTO;

namespace SgsCbrService.Core.WebApiResponses
{
    public class GetCurrenciesResponse : Response
    {
        public int Count { get; set; }

        public int Offset { get; set; }

        public DateTime Date { get; set; }

        public ICollection<CurrencyDto> Currencies { get; set; }
    }
}

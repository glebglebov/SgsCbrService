using System;
using System.Collections.Generic;
using SgsCbrService.Core.DTO;

namespace SgsCbrService.Core.WebApiResponses
{
    public class GetCurrenciesResponse : Response
    {
        public DateTime Date { get; set; }

        public ICollection<CurrencyDto> Currencies { get; set; }
    }
}

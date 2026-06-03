using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stocks;
using api.Models;

namespace api.Mapper
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stocks stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel .Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDividend = stockModel.LastDividend,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }
    }
}
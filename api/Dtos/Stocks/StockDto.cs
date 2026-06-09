using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comments;

namespace api.Dtos.Stocks
{
    public class StockDto
    {

        public int Id { get; set; }


        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;


        public decimal Purchase { get; set; }


        public decimal LastDividend { get; set; }

        public string Industry { get; set; } = string.Empty;

        
        public string MarketCap { get; set; } = string.Empty;

        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

    }
}

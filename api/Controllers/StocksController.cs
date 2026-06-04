using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stocks;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StocksController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks
                .Select(s => s.ToStockDto())
                .ToList();

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);


            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (stockModel == null)
            {
                return NotFound();
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDividend = updateDto.LastDividend;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToStockDto());
        }
    }

}
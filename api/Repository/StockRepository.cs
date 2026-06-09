using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stocks;
using api.Helpers;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository: IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stocks> CreateAsync(Stocks stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stocks?> DeleteAsync(int id) 
        {
            var stockModel = await _context.Stocks.FindAsync(id);

            if(stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Models.Stocks>> GetAllAsync(QueryObject query)
        {
           var stocks =  _context.Stocks.Include(c => c.Comments).AsQueryable();

           if(!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }


            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s=>s.Symbol): stocks.OrderBy(s=>s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber -1) * query.PageSize;


            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

   

        public async Task<Stocks?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> StockExistsAsync(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stocks.FindAsync(id);
            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDividend = stockDto.LastDividend;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortflioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortflioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stocks>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portfolios
    .Where(p => p.AppUserId == user.Id)
    .Select(p => new Stocks
    {
        Id = p.Stocks.Id,
        Symbol = p.Stocks.Symbol,
        CompanyName = p.Stocks.CompanyName,
        Purchase = p.Stocks.Purchase,
        LastDividend = p.Stocks.LastDividend,
        Industry = p.Stocks.Industry,
        MarketCap = p.Stocks.MarketCap
    })
    .ToListAsync();
        }
    }
}
using api.Data;
using api.DTOs.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null) return null;

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks =  _context.Stocks.Include(c => c.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                switch (query.SortBy.ToLower())
                {
                    case "symbol":
                        stocks = query.IsAscending ? stocks.OrderBy(s => s.Symbol) : stocks.OrderByDescending(s => s.Symbol);
                        break;
                    case "companyname":
                        stocks = query.IsAscending ? stocks.OrderBy(s => s.CompanyName) : stocks.OrderByDescending(s => s.CompanyName);
                        break;
                    case "purchase":
                        stocks = query.IsAscending ? stocks.OrderBy(s => s.Purchase) : stocks.OrderByDescending(s => s.Purchase);
                        break;
                    case "lastdiv":
                        stocks = query.IsAscending ? stocks.OrderBy(s => s.LastDiv) : stocks.OrderByDescending(s => s.LastDiv);
                        break;
                    case "industry":
                        stocks = query.IsAscending ? stocks.OrderBy(s => s.Industry) : stocks.OrderByDescending(s => s.Industry);
                        break;
                    case "marketcap":
                        stocks = query.IsAscending ? stocks.OrderBy(s => s.MarketCap) : stocks.OrderByDescending(s => s.MarketCap);
                        break;
                    default:
                        break;
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock> UpdateAsync(int id, UpdateStockRequestDTO updateStockRequestDto)
        {
            var selectedStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (selectedStock == null) return null;

            selectedStock.Symbol = updateStockRequestDto.Symbol;
            selectedStock.CompanyName = updateStockRequestDto.CompanyName;
            selectedStock.Purchase = updateStockRequestDto.Purchase;
            selectedStock.LastDiv = updateStockRequestDto.LastDiv;
            selectedStock.Industry = updateStockRequestDto.Industry;
            selectedStock.MarketCap = updateStockRequestDto.MarketCap;

            await _context.SaveChangesAsync();

            return selectedStock;
        }
    }
}

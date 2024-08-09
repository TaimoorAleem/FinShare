using api.Data;
using api.DTOs.Stock;
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

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
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

using api.DTOs.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);

        Task<Stock?> GetByIdAsync(int id); // FirstOrDefault CAN be null

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock> UpdateAsync(int id, UpdateStockRequestDTO updateStockRequestDto);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}
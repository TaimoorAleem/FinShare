using api.Models;
using Server.Models;

namespace Server.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);

        Task<Portfolio> AddToPortfolioAsync(Portfolio portfolio);

        Task<Portfolio> DeleteFromPortfolio(AppUser appUser, string symbol);
    }
}

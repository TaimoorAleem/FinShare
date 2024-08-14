using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Extensions;
using Server.Interfaces;
using Server.Models;
using System.Globalization;

namespace Server.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null) return BadRequest("Unable to find with the specified symbol.");

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            if (userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower())) return BadRequest("Unable to add same stock to portfolio.");

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };

            await _portfolioRepository.AddToPortfolioAsync(portfolioModel);

            if (portfolioModel == null) return StatusCode(500, "Unable to create");

            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteFromPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(s => s.Symbol .ToLower() == symbol.ToLower()).ToList();

            if (filteredStock.Count() == 1)
            {
                await _portfolioRepository.DeleteFromPortfolio(appUser, symbol);
            }
            else return BadRequest("Unable to find stock with the specified symbol in your portfolio!");

            return Ok();
        }
    }
}

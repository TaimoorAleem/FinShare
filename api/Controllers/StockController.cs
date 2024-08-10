using api.Data;
using api.DTOs.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stocks = await _stockRepository.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.ToStockDTO());

            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null) return NotFound("Unable to find stock with the specified Id"); 

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockRepository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO updateStockRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = await _stockRepository.UpdateAsync(id, updateStockRequestDto);
            if (stockModel == null) return NotFound("Unable to find stock with the specified Id");

            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = await _stockRepository.DeleteAsync(id);
            if (stockModel == null) return NotFound("Unable to find stock with the specified Id");

            return NoContent();
        }
    }
}
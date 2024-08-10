﻿using api.DTOs.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDTO());

            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) return NotFound();

            return Ok(comment.ToCommentDTO());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDTO createCommentDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _stockRepository.StockExists(stockId)) return BadRequest("Stock does not exist!");

            var commentModel = createCommentDTO.ToCommentFromCreate(stockId);
            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDTO updateCommentRequestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepository.UpdateAsync(id, updateCommentRequestDTO.ToCommentFromUpdate());
            if (comment == null) return NotFound("Comment does not exist!");

            return Ok(comment.ToCommentDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var commentModel = await _commentRepository.DeleteAsync(id);
            if (commentModel == null) return NotFound("Comment does not exist!");

            return Ok(commentModel);
        }
    }
}

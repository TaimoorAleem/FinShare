using api.DTOs.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CreatedBy = commentModel.AppUser.UserName,
                StockId = commentModel.StockId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDTO createCommentDTO, int stockId)
        {
            return new Comment
            {
                Title = createCommentDTO.Title,
                Content = createCommentDTO.Content,
                StockId = stockId,
            };
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDTO updateCommentDTO)
        {
            return new Comment
            {
                Title = updateCommentDTO.Title,
                Content = updateCommentDTO.Content
            };
        }
    }
}

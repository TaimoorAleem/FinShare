using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Comment
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Title must be atleast 5 characters")]
        [MaxLength(280, ErrorMessage = "Title can not be longer than 280 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Content must be atleast 5 characters")]
        [MaxLength(280, ErrorMessage = "Content can not be longer than 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}

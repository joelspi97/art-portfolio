using System.ComponentModel.DataAnnotations;

namespace art_portfolio_api.Models.DTOs
{
    public class UpdateArtPieceDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title has to be a minimum of 5 characters long")]
        [MaxLength(40, ErrorMessage = "Title has to be 40 or shorter than 40 characters long")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateOnly CreatedAt { get; set; }

        [Required]
        public List<int> MediumIds { get; set; }

        [Required]
        public int TypeId { get; set; }
    }
}

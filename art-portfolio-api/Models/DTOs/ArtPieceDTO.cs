using art_portfolio_api.Models.DomainModels;

namespace art_portfolio_api.Models.DTOs
{
    public class ArtPieceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly CreatedAt { get; set; } // Debería ponerlo como null? 
        public List<MediumDTO> Mediums { get; set; }
        public ArtPieceType Type { get; set; }
    }
}

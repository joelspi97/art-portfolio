namespace art_portfolio_api.Models.DomainModels
{
    public class ArtPiece
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly CreatedAt { get; set; }
        public List<Medium> Mediums { get; set; }
        public ArtPieceType Type { get; set; }
    }
}
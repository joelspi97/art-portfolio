namespace art_portfolio_api.Models.DomainModels
{
    public class ArtPiecePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public ArtPiece ArtPiece { get; set; }
    }
}

using art_portfolio_api.Models.DomainModels;
using art_portfolio_api.Models.DTOs;

namespace art_portfolio_api.Interfaces
{
    public interface IArtPiecesRepository
    {
        Task<List<ArtPiece>> GetAllAsync(string? type, int pageNumber, int pageSize);
        Task<ArtPiece?> FindByIdAsync(int id);
        Task<ArtPiece> CreateArtPieceAsync(ArtPiece newArtPiece);
        Task<ArtPiece?> FindAndDeleteArtPieceAsync(int id);
        Task<ArtPiece?> FindAndUpdateArtPieceAsync(int id, UpdateArtPieceDTO updateArtPieceDTO);
    }
}

using art_portfolio_api.Data;
using art_portfolio_api.Interfaces;
using art_portfolio_api.Models.DomainModels;
using art_portfolio_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace art_portfolio_api.Repositories
{
    public class ArtPiecesRepository : IArtPiecesRepository
    {
        private readonly ArtPortfolioDbContext _artPortfolioDbContext;
        private readonly IMediumsRepository _mediumsRepository;
        private readonly IArtPieceTypesRepository _artPieceTypesRepository;

        public ArtPiecesRepository(ArtPortfolioDbContext artPortfolioDbContext, 
            IMediumsRepository mediumsRepository, IArtPieceTypesRepository artPieceTypesRepository)
        {
            _artPortfolioDbContext = artPortfolioDbContext;
            _mediumsRepository = mediumsRepository;
            _artPieceTypesRepository = artPieceTypesRepository;
        }

        public async Task<List<ArtPiece>> GetAllAsync(
            string? type = null, 
            int pageNumber = 1, 
            int pageSize = 1000
        ) {
            IQueryable<ArtPiece> query = _artPortfolioDbContext.ArtPieces
                .Include(ap => ap.Mediums)
                .Include(ap => ap.Type)
                .OrderByDescending(ap => ap.CreatedAt)
                .AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(ap => ap.Type.Name == type);
            }

            if (pageNumber >= 1 && pageSize >= 1)
            {
                int skipResults = ((int)pageNumber - 1) * (int)pageSize;
                query = query.Skip(skipResults).Take(pageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<ArtPiece?> FindByIdAsync(int id)
        {
            return await _artPortfolioDbContext.ArtPieces
                .Include(ap => ap.Mediums)
                .Include(ap => ap.Type)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ArtPiece> CreateArtPieceAsync(ArtPiece newArtPiece)
        {
            await _artPortfolioDbContext.ArtPieces.AddAsync(newArtPiece);
            await _artPortfolioDbContext.SaveChangesAsync();
            return newArtPiece;
        }

        public async Task<ArtPiece?> FindAndDeleteArtPieceAsync(int id)
        {
            ArtPiece? existingArtPiece = await _artPortfolioDbContext.ArtPieces.FirstOrDefaultAsync(x => x.Id == id);
            if (existingArtPiece == null) return null;

            _artPortfolioDbContext.Remove(existingArtPiece);
            await _artPortfolioDbContext.SaveChangesAsync();
            return existingArtPiece;
        }

        public async Task<ArtPiece?> FindAndUpdateArtPieceAsync(int id, UpdateArtPieceDTO updateArtPieceDTO)
        {
            ArtPiece? artPiece = await FindByIdAsync(id);
            if (artPiece == null) return null;

            List<Medium> selectedMediums = await _mediumsRepository.GetMediumsByIdsAsync(updateArtPieceDTO.MediumIds);
            if (selectedMediums.Count == 0) return null;

            ArtPieceType? selectedArtPieceType = await _artPieceTypesRepository.GetTypeById(updateArtPieceDTO.TypeId);
            if (selectedArtPieceType == null) return null;

            artPiece.Title = updateArtPieceDTO.Title;
            artPiece.Description = updateArtPieceDTO.Description;
            artPiece.CreatedAt = updateArtPieceDTO.CreatedAt;
            artPiece.Mediums = selectedMediums;
            artPiece.Type = selectedArtPieceType;

            await _artPortfolioDbContext.SaveChangesAsync();
            return artPiece;
        }
    }
}

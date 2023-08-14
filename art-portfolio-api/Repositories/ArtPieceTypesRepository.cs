using art_portfolio_api.Data;
using art_portfolio_api.Interfaces;
using art_portfolio_api.Models.DomainModels;

namespace art_portfolio_api.Repositories
{
    public class ArtPieceTypesRepository : IArtPieceTypesRepository
    {
        private readonly ArtPortfolioDbContext _artPortfolioDbContext;

        public ArtPieceTypesRepository(ArtPortfolioDbContext artPortfolioDbContext)
        {
            _artPortfolioDbContext = artPortfolioDbContext;
        }

        public async Task<ArtPieceType?> GetTypeById(int typeId)
        {
            return await _artPortfolioDbContext.ArtPieceTypes.FindAsync(typeId);
        }
    }
}

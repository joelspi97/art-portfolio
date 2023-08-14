using art_portfolio_api.Data;
using art_portfolio_api.Interfaces;
using art_portfolio_api.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace art_portfolio_api.Repositories
{
    public class MediumsRepository : IMediumsRepository
    {
        private readonly ArtPortfolioDbContext _artPortfolioDbContext;

        public MediumsRepository(ArtPortfolioDbContext artPortfolioDbContext)
        {
            _artPortfolioDbContext = artPortfolioDbContext;
        }

        public async Task<List<Medium>> GetMediumsAsync()
        {
            return await _artPortfolioDbContext.Mediums.ToListAsync();
        }

        public async Task<List<Medium>> GetMediumsByIdsAsync(List<int> mediumIds)
        {
            return await _artPortfolioDbContext.Mediums
                .Where(m => mediumIds.Contains(m.Id))
                .ToListAsync();
        }
    }
}

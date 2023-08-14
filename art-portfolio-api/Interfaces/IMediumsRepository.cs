using art_portfolio_api.Models.DomainModels;

namespace art_portfolio_api.Interfaces
{
    public interface IMediumsRepository
    {
        Task<List<Medium>> GetMediumsAsync();
        Task<List<Medium>> GetMediumsByIdsAsync(List<int> mediumIds);
    }
}

using art_portfolio_api.Data;
using art_portfolio_api.Interfaces;
using art_portfolio_api.Mappings;
using art_portfolio_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace art_portfolio_api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Swagger 
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // END Swagger 

            services.AddDbContext<ArtPortfolioDbContext>(options => 
                options.UseSqlServer(config.GetConnectionString("ArtPortfolioConnectionString")));

            services.AddAutoMapper(typeof(AutoMapperProfiles));

            // Repositories 
            services.AddScoped<IArtPiecesRepository, ArtPiecesRepository>();
            services.AddScoped<IMediumsRepository, MediumsRepository>();
            services.AddScoped<IArtPieceTypesRepository, ArtPieceTypesRepository>();
            // END Repositories 

            return services;
        }
    }
}
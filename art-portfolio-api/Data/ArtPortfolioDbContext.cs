using art_portfolio_api.Helpers;
using art_portfolio_api.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace art_portfolio_api.Data
{
    public class ArtPortfolioDbContext : DbContext
    {
        public ArtPortfolioDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<ArtPiece> ArtPieces { get; set; }
        public DbSet<Medium> Mediums { get; set; }

        public DbSet<ArtPieceType> ArtPieceTypes { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArtPiece>()
                .HasMany(ap => ap.Mediums)
                .WithMany()
                .UsingEntity(j => j.ToTable("ArtPieceMedium"));

            // Seed data for mediums
            List<Medium> mediumsSeed = new()
            {
                new Medium()
                {
                    Id = 1,
                    Name = "Óleo"
                },
                new Medium()
                {
                    Id = 2,
                    Name = "Témpera"
                },
                new Medium()
                {
                    Id = 3,
                    Name = "Acuarela"
                },
                new Medium()
                {
                    Id = 4,
                    Name = "Acrílico"
                },
                new Medium()
                {
                    Id = 5,
                    Name = "Pastel Graso"
                },
                new Medium()
                {
                    Id = 6,
                    Name = "Pastel Tiza"
                },                
                new Medium()
                {
                    Id = 7,
                    Name = "Grafito"
                }
            };

            modelBuilder.Entity<Medium>().HasData(mediumsSeed);

            // Seed data for art piece types 
            List<ArtPieceType> artPieceTypesSeed = new()
            {
                new ArtPieceType()
                {
                    Id = 1,
                    Name = "Dibujo"
                },
                 new ArtPieceType()
                {
                    Id = 2,
                    Name = "Boceto"
                },
                new ArtPieceType()
                {
                    Id = 3,
                    Name = "Mural"
                },
                new ArtPieceType()
                {
                    Id = 4,
                    Name = "Pintura"
                }
            };

            modelBuilder.Entity<ArtPieceType>().HasData(artPieceTypesSeed);
        }
    }
}
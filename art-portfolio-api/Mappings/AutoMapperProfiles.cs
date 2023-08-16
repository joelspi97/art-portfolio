using art_portfolio_api.Models.DomainModels;
using art_portfolio_api.Models.DTOs;
using AutoMapper;

namespace art_portfolio_api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Art pieces 
            CreateMap<ArtPiece, ArtPieceDTO>().ReverseMap();

            // Mediums 
            CreateMap<Medium, MediumDTO>().ReverseMap();

            // Types 
            CreateMap<ArtPieceType, ArtPieceTypeDTO>().ReverseMap();
        }
    }
}

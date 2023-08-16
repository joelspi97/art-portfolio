using art_portfolio_api.Interfaces;
using art_portfolio_api.Models.DomainModels;
using art_portfolio_api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace art_portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtPieceTypesController : ControllerBase
    {
        private readonly IArtPieceTypesRepository _artPieceTypesRepository;
        private readonly IMapper _mapper;

        public ArtPieceTypesController(IArtPieceTypesRepository artPieceTypesRepository, IMapper mapper)
        {
            _artPieceTypesRepository = artPieceTypesRepository;
            _mapper = mapper;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<ArtPieceTypeDTO>>> GetArtPieceTypes() 
        {
            List<ArtPieceType> artPieceTypesDomainModel = await this._artPieceTypesRepository.GetArtPieceTypes();
            return Ok(_mapper.Map<List<ArtPieceTypeDTO>>(artPieceTypesDomainModel));
        }
    }
}
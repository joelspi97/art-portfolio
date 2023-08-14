using art_portfolio_api.Interfaces;
using art_portfolio_api.Models.DomainModels;
using art_portfolio_api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace art_portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtPiecesController : ControllerBase
    {
        private readonly IArtPiecesRepository _artPiecesRepository;
        private readonly IMapper _mapper;
        private readonly IMediumsRepository _mediumsRepository;
        private readonly IArtPieceTypesRepository _artPieceTypesRepository;

        public ArtPiecesController(IArtPiecesRepository artPiecesRepository, 
            IMapper mapper, IMediumsRepository mediumsRepository, IArtPieceTypesRepository artPieceTypesRepository)
        {
            _artPiecesRepository = artPiecesRepository;
            _mapper = mapper;
            _mediumsRepository = mediumsRepository;
            _artPieceTypesRepository = artPieceTypesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArtPieceDTO>>> GetArtPieces(
            [FromQuery] string? type, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            List<ArtPiece> artPiecesDomainModels = await _artPiecesRepository.GetAllAsync(type, pageNumber, pageSize);

            return Ok(_mapper.Map<List<ArtPieceDTO>>(artPiecesDomainModels));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<ArtPieceDTO>>> GetArtPiece([FromRoute] int id)
        {
            ArtPiece? artPieceDomainModel = await _artPiecesRepository.FindByIdAsync(id);
            if (artPieceDomainModel == null) return NotFound("The Id doesn't match any art piece");

            return Ok(_mapper.Map<ArtPieceDTO>(artPieceDomainModel));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtPiece([FromBody] CreateArtPieceDTO createArtPieceDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            List<Medium> selectedMediums = await _mediumsRepository.GetMediumsByIdsAsync(createArtPieceDTO.MediumIds);
            if (selectedMediums.Count == 0) return NotFound("Could not find some mediums used for this art piece");

            ArtPieceType? selectedArtPieceType = await _artPieceTypesRepository.GetTypeById(createArtPieceDTO.TypeId);
            if (selectedArtPieceType == null) return NotFound("Could not find indicated art piece type");

            ArtPiece artPieceDomainModel = new()
            {
                Title = createArtPieceDTO.Title,
                Description = createArtPieceDTO.Description,
                CreatedAt = createArtPieceDTO.CreatedAt,
                Mediums = selectedMediums,
                Type = selectedArtPieceType
            };

            ArtPiece? createdObject = await _artPiecesRepository.CreateArtPieceAsync(artPieceDomainModel);
            if (createdObject == null) return StatusCode(500);

            ArtPieceDTO artPieceDTO = _mapper.Map<ArtPieceDTO>(createdObject);
            return CreatedAtAction(nameof(GetArtPiece), new { id = createdObject.Id }, artPieceDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteArtPiece([FromRoute] int id)
        {
            ArtPiece? deletedArtPiece = await _artPiecesRepository.FindAndDeleteArtPieceAsync(id);
            if (deletedArtPiece == null) return NotFound("The Id doesn't match any art piece");

            return Ok(_mapper.Map<ArtPieceDTO>(deletedArtPiece));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ArtPieceDTO>> UpdateArtPiece([FromRoute] int id, [FromBody] UpdateArtPieceDTO updateArtPieceDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ArtPiece? updatedArtPiece = await _artPiecesRepository.FindAndUpdateArtPieceAsync(id, updateArtPieceDTO);
            if (updatedArtPiece == null) return NotFound("Could not find art piece or some of its related mediums");

            return Ok(_mapper.Map<ArtPieceDTO>(updatedArtPiece));
        }
    }
}

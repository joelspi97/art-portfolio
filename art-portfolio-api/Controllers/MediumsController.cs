using art_portfolio_api.Interfaces;
using art_portfolio_api.Models.DomainModels;
using art_portfolio_api.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace art_portfolio_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediumsController : ControllerBase
    {
        private readonly IMediumsRepository _mediumsRepository;
        private readonly IMapper _mapper;

        public MediumsController(IMediumsRepository mediumsRepository, IMapper mapper)
        {
            _mediumsRepository = mediumsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediumDTO>>> GetMediums()
        {
            List<Medium> mediums = await _mediumsRepository.GetMediumsAsync();

            return Ok(_mapper.Map<List<MediumDTO>>(mediums));
        }
    }
}

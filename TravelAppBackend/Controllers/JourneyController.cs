using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAppBackend.DTO;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly IUserRepository _userRepository;

        public JourneyController(IJourneyRepository journeyRepository, IUserRepository userRepository)
        {
            _journeyRepository = journeyRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<Journey> GetJourneys()
        {
            return _journeyRepository.GetAll();
        }

        [HttpGet("{journeyId}")]
        public ActionResult<Journey> GetJourney(int journeyId)
        {
            Journey journey = _journeyRepository.GetBy(journeyId);
            if(journey == null)
            {
                return NotFound();
            }
            return journey;
        }

        [HttpPost]
        public ActionResult<JourneyDTO> PostJourney(JourneyDTO journeyDTO)
        {
            Journey journey = new Journey()
            {
                Name = journeyDTO.Name,
                Start = DateTime.Now
            };

            journey.User = _userRepository.GetBy(journeyDTO.userId);

            _journeyRepository.Add(journey);
            _journeyRepository.SaveChanges();
            return CreatedAtAction(nameof(GetJourneys), new { id = journey.Id }, journeyDTO);
        }
    }
}

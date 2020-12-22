using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyRepository _journeyRepository;

        public JourneyController(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }

        [HttpGet]
        public IEnumerable<Journey> GetJourneys()
        {
            return _journeyRepository.GetAll();
        }
    }
}

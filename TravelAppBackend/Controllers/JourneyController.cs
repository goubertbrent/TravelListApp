using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IItemRepository _itemRepository;

        public JourneyController(IJourneyRepository journeyRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            _journeyRepository = journeyRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
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
            Debug.WriteLine("Teeeeeeeeeeeeest");
            Debug.WriteLine(journeyDTO.StartDay);
            Debug.WriteLine(journeyDTO.StartMonth);
            Debug.WriteLine(journeyDTO.StartYear);
            Journey journey = new Journey()
            {
                Name = journeyDTO.Name,
                Start = new DateTime(journeyDTO.StartYear,journeyDTO.StartMonth, journeyDTO.StartDay)
            };

            journey.User = _userRepository.GetBy(journeyDTO.userId);

            _journeyRepository.Add(journey);
            _journeyRepository.SaveChanges();
            return CreatedAtAction(nameof(GetJourneys), new { id = journey.Id }, journeyDTO);
        }

        [HttpGet("{journeyId}/items/{itemLineId}")]
        public ActionResult<ItemLine> GetItem(int journeyId, int itemLineId)
        {
            if (!_journeyRepository.TryGetJourney(journeyId, out var journey))
            {
                return NotFound();
            }
            ItemLine itemline = journey.GetItem(itemLineId);
            if(itemline == null)
            {
                return NotFound();
            }
            return itemline;
        }

        [HttpPost("{journeyId}/items")]
        public ActionResult<ItemLine> PostItemLine(int journeyId, ItemLineDTO itemlineDTO)
        {
            if(!_journeyRepository.TryGetJourney(journeyId, out var journey))
            {
                return NotFound();
            }

            ItemLine itemline = new ItemLine()
            {
                Amount = itemlineDTO.Amount
                
            };

            itemline.Item = _itemRepository.getById(itemlineDTO.ItemId);
            journey.addItem(itemline);
            _journeyRepository.SaveChanges();
            return CreatedAtAction("GetJourneys", new { id= journey.Id, itemlineId = itemline.Id }, itemline);
        }
    }
}

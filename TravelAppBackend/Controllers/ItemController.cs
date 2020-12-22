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
    public class ItemController : ControllerBase
    {
        #region Fields
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        #endregion
        #region Constructor
        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
        }
        #endregion
        #region APICalls
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetAll();
        }

        [HttpPost]
        public ActionResult<Item> PostItem(ItemDTO itemDTO)
        {
            if(_itemRepository.findName(itemDTO.Name))
            {
                return BadRequest();
            }
            Item item = new Item()
            {
                Name = itemDTO.Name
            };
            item.Category = _categoryRepository.getById(itemDTO.CategoryId);
            _itemRepository.Add(item);
            _itemRepository.SaveChanges();
            return CreatedAtAction(nameof(GetItems), new { id = item.Id }, itemDTO);
        }
        #endregion



    }
}

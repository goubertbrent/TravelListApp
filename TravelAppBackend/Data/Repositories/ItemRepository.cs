using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Item> _items;
        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _items = _dbContext.Items;
        }
        public Item getById(int itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }
    }
}

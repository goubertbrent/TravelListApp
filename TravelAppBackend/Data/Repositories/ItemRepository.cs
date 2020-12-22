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

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public bool findName(string name)
        {
            Item item = _items.SingleOrDefault(i => i.Name == name);
            return item != null;
        }

        public IEnumerable<Item> GetAll()
        {
            return _items.Include(i => i.Category).ToList();
        }

        public Item getById(int itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

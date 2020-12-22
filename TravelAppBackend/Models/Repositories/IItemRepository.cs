using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Item getById(int itemId);
        void Add(Item item);
        bool findName(string name);
        void SaveChanges();
    }
}

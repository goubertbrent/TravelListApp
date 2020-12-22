using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models.Repositories
{
    public interface IItemRepository
    {
        Item getById(int itemId);
    }
}

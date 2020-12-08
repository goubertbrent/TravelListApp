using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models.Repositories
{
    interface IJourneyRepository
    {
        IEnumerable<Journey> GetAll();
        IEnumerable<Journey> GetByUser(int userId);
        Journey GetBy(int journeyId);
        void Add(Journey journey);
        void Delete(Journey journey);
        void SaveChanges();

    }
}

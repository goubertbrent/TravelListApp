using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext _context;
        public DataInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            if(_context.Database.EnsureCreated())
            {

            }
        }
    }
}

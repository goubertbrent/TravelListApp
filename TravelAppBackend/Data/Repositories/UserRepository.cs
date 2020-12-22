using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<User> _users;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _users = dbContext.Users;
        }

        public User GetBy(int userId)
        {
            return _users.SingleOrDefault(u => u.Id == userId);
        }
    }
}

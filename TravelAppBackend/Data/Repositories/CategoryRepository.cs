using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Category> _categories;
        #endregion
        #region Constructors
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _categories = dbContext.Categories;
        }
        #endregion
        #region Methods
        public Category getById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }
        #endregion


    }
}

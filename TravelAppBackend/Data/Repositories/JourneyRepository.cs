﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using TravelAppBackend.Models.Repositories;

namespace TravelAppBackend.Data.Repositories
{
    public class JourneyRepository : IJourneyRepository

    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Journey> _journeys;

        public JourneyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _journeys = dbContext.Journeys;
        }

        public void Add(Journey journey)
        {
            _journeys.Add(journey);
        }

        public void Delete(Journey journey)
        {
            _journeys.Remove(journey);
        }

        public IEnumerable<Journey> GetAll()
        {
            return _journeys.ToList();
        }

        public Journey GetBy(int journeyId)
        {
            return _journeys.Include(j => j.Items).ThenInclude(il => il.Item).Include(j => j.Tasks).SingleOrDefault(j => j.Id == journeyId);
        }

        public IEnumerable<Journey> GetByUser(int userId)
        {
            return _journeys.Where(j => j.User.Id == userId).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool TryGetJourney(int id, out Journey journey)
        {
            journey = _dbContext.Journeys.Include(j => j.Items).FirstOrDefault(j => j.Id == id);
            return journey != null;
        }
    }
}

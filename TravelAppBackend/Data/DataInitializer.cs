using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;
using Task = TravelAppBackend.Models.Task;

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
                User user1 = new User() { Username = "Brent Goubert" };

                _context.Users.Add(user1);
                _context.SaveChanges();

                Category badkamer = new Category() {Name="badkamer", User = user1 };
                Category slaapkamer = new Category() { Name = "slaapkamer", User = user1 };

                Item item1 = new Item() { Name = "tandenborstel", Category = badkamer };
                Item item2 = new Item() { Name = "tandpasta", Category = badkamer };
                Item item3 = new Item() { Name = "kussen", Category = slaapkamer };
                _context.Items.Add(item1);
                _context.Items.Add(item2);
                _context.Items.Add(item3);
                _context.SaveChanges();

                Task task1 = new Task() { Description = "Visum bestellen online" };
                Task task2 = new Task() { Description = "Batterij gsm opladen" };

                ItemLine itemline1 = new ItemLine() { Item = item1, Amount = 2 };
                ItemLine itemline2 = new ItemLine() { Item = item2, Amount = 1 };
                ItemLine itemline3 = new ItemLine() { Item = item3, Amount = 3 };

                Journey journey = new Journey() {Name = "Frankrijk caravan",Start = DateTime.Now.AddDays(15), User = user1 };
                journey.addItem(itemline1);
                journey.addItem(itemline2);
                journey.addItem(itemline3);
                journey.addTask(task1);
                journey.addTask(task2);
                _context.Journeys.Add(journey);


                _context.SaveChanges();
            }
        }
    }
}

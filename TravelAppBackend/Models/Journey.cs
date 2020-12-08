using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models
{
    public class Journey
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public List<ItemLine> Items { get; set; }
        public List<Task> Tasks { get; set; }
        public User User { get; set; }
    }
}

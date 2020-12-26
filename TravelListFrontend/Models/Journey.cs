using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListFrontend.Models
{
    public class Journey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public List<ItemLine> Items { get; set; }
        public List<Task> Tasks { get; set; }
        public User User { get; set; }
    }
}

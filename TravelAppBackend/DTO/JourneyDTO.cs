using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Models;

namespace TravelAppBackend.DTO
{
    public class JourneyDTO
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int userId { get; set; }
    }
}

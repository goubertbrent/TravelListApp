using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelListFrontend.Models
{
    public class ItemLine
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }
    }
}

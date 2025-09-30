using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSportsApi.Entity
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}

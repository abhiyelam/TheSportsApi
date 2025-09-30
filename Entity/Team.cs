using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSportsApi.Entity
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Abbr { get; set; }
        public string Suffix { get; set; }
        public string Logo { get; set; }
        public int Gender { get; set; }
        public int National { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

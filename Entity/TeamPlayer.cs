using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSportsApi.Entity
{
    public class TeamPlayer
    {
        public string MatchId { get; set; }
        public string PlayerId { get; set; }
        public string Position { get; set; }
        public string Type { get; set; }
        public string Captain { get; set; }
        public string TeamType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSportsApi.Entity
{
    public class Player
    {
        public string Id { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PageTile { get; set; }
        public string Logo { get; set; }
        public long Birthday { get; set; }
        public long UpdatedAt { get; set; }
       // public  List<Player> players { get; set; }
    }
    public class PlayerResponse
    {
       
        public List<Player> Players { get; set; }
    }
}

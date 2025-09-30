using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheSportsApi.DataBaseLogic;
using TheSportsApi.Entity;
 
namespace TheSportsApi.BLogic
{
    public class PlayerService
    {
        //private static readonly HttpClient client = new HttpClient();
        string plyerlisturl = "https://api.thesports.com/v1/cricket/player/list?user={0}&secret={1}";
        public bool Sport_GetPlayer(string username,string secretekey)
        {
            List<Player> playerslist = new List<Player>();

            string readurl = string.Format(plyerlisturl, username, secretekey);
            try
            {
                HttpResponseMessage response = client.GetAsync(readurl).Result; // Blocking call to wait for result
                response.EnsureSuccessStatusCode(); 

                string responseBody = response.Content.ReadAsStringAsync().Result; // Blocking call to read content
                var json = JObject.Parse(responseBody);
                playerslist = json["results"].ToObject<List<Player>>();

                if (playerslist != null)
                {
                    var dal = new PlayerDal();
                    dal.SavePlayer(playerslist);
                }


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch data: {ex.Message}");
            }

            return true;
        }
    }
}

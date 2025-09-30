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
    public class TeamService
    {
        private static readonly HttpClient client = new HttpClient();
        string teamlisturl = "https://api.thesports.com/v1/cricket/team/list?user={0}&secret={1}";
        public bool sport_GetTeams(string username, string secretekey)
        {
            List<Team> teamslist = new List<Team>();

            string readurl = string.Format(teamlisturl, username, secretekey);
            try
            {
                HttpResponseMessage response = client.GetAsync(readurl).Result; // Blocking call to wait for result
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result; // Blocking call to read content
                var json = JObject.Parse(responseBody);
                teamslist = json["results"].ToObject<List<Team>>();

                if (teamslist != null)
                {
                    TeamDal dal = new TeamDal();
                    dal.sport_SaveTeam(teamslist);
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

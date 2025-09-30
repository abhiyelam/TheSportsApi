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
    public class VenueService
    {

        private static readonly HttpClient client = new HttpClient();
        string venuelisturl = "https://api.thesports.com/v1/cricket/venue/list?user={0}&secret={1}";
        public bool sport_GetVenue(string username, string secretekey)
        {
            List<Venue> venuelist = new List<Venue>();

            string readurl = string.Format(venuelisturl, username, secretekey);
            try
            {
                HttpResponseMessage response = client.GetAsync(readurl).Result; // Blocking call to wait for result
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result; // Blocking call to read content
                var json = JObject.Parse(responseBody);
                venuelist = json["results"].ToObject<List<Venue>>();

                if (venuelist != null)
                {
                    VenueDal dal = new VenueDal();
                    dal.sport_SaveVenue(venuelist);
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


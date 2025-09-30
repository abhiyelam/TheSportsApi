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
    public class CountryService
    {

        private static readonly HttpClient client = new HttpClient();
        string countrylisturl = "https://api.thesports.com/v1/cricket/country/list?user={0}&secret={1}";
        public bool sport_GetCountry(string username, string secretekey)
        {
            List<Country> countrylist = new List<Country>();

            string readurl = string.Format(countrylisturl, username, secretekey);
            try
            {
                HttpResponseMessage response = client.GetAsync(readurl).Result; // Blocking call to wait for result
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result; // Blocking call to read content
                var json = JObject.Parse(responseBody);
                countrylist = json["results"].ToObject<List<Country>>();

                if (countrylist != null)
                {
                    CountryDal dal = new CountryDal();
                    dal.sport_SaveCountry(countrylist);
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

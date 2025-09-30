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
   public class CategoryService
    {
        private static readonly HttpClient client = new HttpClient();
        string categorylisturl = "https://api.thesports.com/v1/cricket/category/list?user={0}&secret={1}";
        public bool sport_GetCategory(string username, string secretekey)
        {
            List<Category> categorylist = new List<Category>();

            string readurl = string.Format(categorylisturl, username, secretekey);
            try
            {
                HttpResponseMessage response = client.GetAsync(readurl).Result; // Blocking call to wait for result
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result; // Blocking call to read content
                var json = JObject.Parse(responseBody);
                categorylist = json["results"].ToObject<List<Category>>();

                if (categorylist != null)
                {
                    CategoryDal dal = new CategoryDal();
                    dal.sport_SaveCategory(categorylist);
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

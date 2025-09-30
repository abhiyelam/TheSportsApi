using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using TheSportsApi.BLogic;
using TheSportsApi.DataBaseLogic;
using TheSportsApi.Entity;

namespace TheSportsApi
{
   public class Program
    {
        public static string ApiUser = "";
        public static string SecretKey = "";
     
        static void Main(string[] args)
        {

            ApiUser = ConfigurationManager.AppSettings["APIUSER"].ToString();
            SecretKey = ConfigurationManager.AppSettings["SECRETKEY"].ToString();
           string Id = "ednm96cwxxg0myo";

            Console.WriteLine("The Sports Api Start at " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));
            Console.WriteLine("Reading player");
            // ReadPlayer(ApiUser,SecretKey);
            //ReadTeam(ApiUser, SecretKey);
            // ReadVenue(ApiUser, SecretKey);
            //ReadCountry(ApiUser, SecretKey);
            //ReadCategory(ApiUser, SecretKey);
            MatchesDal matchesDal = new MatchesDal();
            List<Team> matches = matchesDal.GetMatchId();
            Console.WriteLine("The Sports Api End at " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm"));
            ReadMatchesData(ApiUser, SecretKey, Id);

            //foreach (var t in matches)
            //{
            //    ReadMatchesData(ApiUser, SecretKey, t.Id);
            //}


        }

        //public static void ReadPlayer(string apiuser,string key)
        //{
        //    PlayerService playerService = new PlayerService();
        //    playerService.Sport_GetPlayer(apiuser,key);
        //    playerService = null;

        //}
        //public static void ReadTeam(string apiuser, string key)
        //{
        //    TeamService teamService = new TeamService();
        //    teamService.sport_GetTeams(apiuser, key);

        //}
        //public static void ReadVenue(string apiuser, string key)
        //{
        //    VenueService venueService = new VenueService();
        //    venueService.sport_GetVenue(apiuser, key);

        //}
        //public static void ReadCountry(string apiuser, string key)
        //{
        //    CountryService countryService = new CountryService();
        //    countryService.sport_GetCountry(apiuser, key);

        //}

        public static void ReadMatchesData(string apiuser, string key,string Id)
        {
            MatchesService matchesService = new MatchesService();
            matchesService.sport_GetTeamPlayer(apiuser, key,Id);

        }

       
    }
}

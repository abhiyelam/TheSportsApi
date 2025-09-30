using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSportsApi.Dal;
using TheSportsApi.Entity;

namespace TheSportsApi.DataBaseLogic
{
   public class MatchesDal
   {
        private readonly SQLHelper _sqlHelper;

        public MatchesDal()
        {
            _sqlHelper = new SQLHelper(); 
        }
        public List<Team> GetMatchId()
        {

            

            List<Team> list = new List<Team>();
            //SqlParameter[] para = { new SqlParameter("@siteid", System.Data.SqlDbType.Int)
            //};

            //para[0].Value = siteid;
            try
            {
                DbDataReader reader = null;
                using (reader = _sqlHelper.ExecuteReader("thesport_GetMatchId"))
                {
                    while (reader.Read())
                    {
                        Team team = new Team();
                        team.Id = reader["id"].ToString();
                        list.Add(team);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;

        }
        public bool sport_SaveTeamPlayer(List<Player> players)
        {
            bool flag = false;
            try
            {
                foreach (var player in players)
                {
                    SqlParameter[] prm = {
                        new SqlParameter("@id", SqlDbType.VarChar),
                        new SqlParameter("@country_id", SqlDbType.VarChar),
                       new SqlParameter("@name", SqlDbType.VarChar),
                       new SqlParameter("@short_name", SqlDbType.VarChar),
                        new SqlParameter("@logo", SqlDbType.VarChar),
                        new SqlParameter("@birthday", SqlDbType.SmallDateTime),
                    };
                    int _Id = Convert.ToInt32(player.Id);
                    prm[0].Value = player.Id;
                    prm[1].Value = player.CountryId != null ? player.CountryId : (object)DBNull.Value;
                    prm[2].Value = player.Name;
                    prm[3].Value = player.ShortName != null ? player.ShortName : (object)DBNull.Value;
                    prm[4].Value = player.Logo;
                    prm[5].Value = DateTimeOffset.FromUnixTimeSeconds(player.Birthday).DateTime;



                    bool result = _sqlHelper.ExecuteNonQuery("theSport_PlayerSave", prm);


                    if (result)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break; // Exit loop early since saving failed
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }
        public bool sport_SaveMatches(List<TeamPlayer> teamPlayers, string id,string teamType)
        {
            bool flag = false;
            try
            {
                foreach (var player in teamPlayers)
                {
                    SqlParameter[] prm = {
                          new SqlParameter("@matchId", SqlDbType.VarChar),
                    new SqlParameter("@playerId", SqlDbType.VarChar),
                    new SqlParameter("@type", SqlDbType.Int),
                    new SqlParameter("@captain", SqlDbType.Int),
                    new SqlParameter("@position", SqlDbType.VarChar),
                    new SqlParameter("@teamType", SqlDbType.VarChar)   // Specify home or away
                   };
                    prm[0].Value = id;
                    prm[1].Value = player.PlayerId != null ? player.PlayerId : (object)DBNull.Value; ;
                    prm[2].Value = player.Type;
                    prm[3].Value = player.Captain;
                    prm[4].Value = player.Position;
                    prm[5].Value = teamType;
                    bool result= _sqlHelper.ExecuteNonQuery("thesport_SaveMatchesTeamPlayer", prm);
                    if (result)
                    {
                        flag = true;
                      
                    }
                    else
                    {
                        flag = false;
                        break; // Exit loop early since saving failed
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;

        }

   }
}

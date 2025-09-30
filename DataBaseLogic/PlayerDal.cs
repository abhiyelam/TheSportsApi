using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSportsApi.Dal;
using TheSportsApi.Entity;

namespace TheSportsApi.DataBaseLogic
{
    public class PlayerDal
    {
        private readonly SQLHelper _sqlHelper;

        public PlayerDal()
        {
            _sqlHelper = new SQLHelper(); // Initialize your SqlHelper instance
        }
        public bool SavePlayer(List<Player> players)
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
                    //int _Id = Convert.ToInt32(player.Id);
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
    }
}

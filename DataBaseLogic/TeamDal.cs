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
     public class TeamDal
     { 
        private readonly SQLHelper _sqlHelper;

        public TeamDal()
        {
            _sqlHelper = new SQLHelper(); 
        }
        public bool sport_SaveTeam(List<Team> teams)
        {
            bool flag = false;
            try
            {
                foreach (var team in teams)
                {
                    SqlParameter[] prm = {
                        new SqlParameter("@id", SqlDbType.VarChar),
                        new SqlParameter("@name", SqlDbType.VarChar),
                       new SqlParameter("@short_name", SqlDbType.VarChar),
                       new SqlParameter("@abbr", SqlDbType.VarChar),
                       new SqlParameter("@suffix", SqlDbType.VarChar),
                        new SqlParameter("@logo", SqlDbType.VarChar),
                        new SqlParameter("@gender", SqlDbType.VarChar),
                        new SqlParameter("@nationality", SqlDbType.VarChar),
                        
                    };
                    //int _Id = Convert.ToInt32(player.Id);
                    prm[0].Value = team.Id;
                    prm[1].Value = team.Name;
                    prm[2].Value = team.ShortName != null ? team.ShortName : (object)DBNull.Value;
                    prm[3].Value = team.Abbr;
                    prm[4].Value = team.Suffix;
                    prm[5].Value = team.Logo;
                    prm[6].Value = team.Gender;
                    prm[7].Value = team.National;
                  


                    bool result = _sqlHelper.ExecuteNonQuery("thesport_TeamSave", prm);


                    if (result)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
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

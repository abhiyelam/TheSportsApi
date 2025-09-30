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
   public class CountryDal
    {
        private readonly SQLHelper _sqlHelper;

        public CountryDal()
        {
            _sqlHelper = new SQLHelper(); // Initialize your SqlHelper instance
        }
        public bool sport_SaveCountry(List<Country> countries)
        {
            bool flag = false;
            try
            {
                foreach (var country in countries)
                {
                    SqlParameter[] prm = {
                        new SqlParameter("@id", SqlDbType.VarChar),
                        new SqlParameter("@name", SqlDbType.VarChar),
                       new SqlParameter("@logo", SqlDbType.VarChar),
                     

                    };
                    //int _Id = Convert.ToInt32(player.Id);
                    prm[0].Value = country.Id;
                    prm[1].Value = country.Name;
                    prm[2].Value = country.Logo;
                  

                    bool result = _sqlHelper.ExecuteNonQuery("thesport_CountrySave", prm);


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

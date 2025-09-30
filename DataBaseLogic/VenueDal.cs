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
   public class VenueDal
    {
        private readonly SQLHelper _sqlHelper;

        public VenueDal()
        {
            _sqlHelper = new SQLHelper(); // Initialize your SqlHelper instance
        }
        public bool sport_SaveVenue(List<Venue> venues)
        {
            bool flag = false;
            try
            {
                foreach (var venue in venues)
                {
                    SqlParameter[] prm = {
                        new SqlParameter("@id", SqlDbType.VarChar),
                        new SqlParameter("@name", SqlDbType.VarChar),
                       new SqlParameter("@city", SqlDbType.VarChar),
                       new SqlParameter("@capacity", SqlDbType.VarChar),
                  
                    };
                    //int _Id = Convert.ToInt32(player.Id);
                    prm[0].Value = venue.Id;
                    prm[1].Value = venue.Name;
                    prm[2].Value = venue.City;
                    prm[3].Value = venue.Capacity;

                     bool result = _sqlHelper.ExecuteNonQuery("thesport_VenueSave", prm);


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

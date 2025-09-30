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
    public class CategoryDal
    {
        private readonly SQLHelper _sqlHelper;

        public CategoryDal()
        {
            _sqlHelper = new SQLHelper(); // Initialize your SqlHelper instance
        }
        public bool sport_SaveCategory(List<Category> categories)
        {
            bool flag = false;
            try
            {
                foreach (var category in categories)
                {
                    SqlParameter[] prm = {
                        new SqlParameter("@id", SqlDbType.VarChar),
                        new SqlParameter("@name", SqlDbType.VarChar),
                       new SqlParameter("@country_id", SqlDbType.VarChar),


                    };
                 
                    prm[0].Value = category.Id;
                    prm[1].Value = category.Name;
                    prm[2].Value = category.CountryId !=null ? category.CountryId :(object)DBNull.Value;


                    bool result = _sqlHelper.ExecuteNonQuery("thesport_CategorySave", prm);


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

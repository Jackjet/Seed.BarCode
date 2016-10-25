using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.BarCodeCore.Dao
{ 
    public class SugarDao
    {
        private SugarDao()
        {

        }
        public static SqlSugarClient GetInstance()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString();
            return new SqlSugarClient(connection);
        }
    }
}

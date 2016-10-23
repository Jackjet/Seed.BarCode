using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteSugar;
using SqlSugar;

namespace Seed.BarCodeCore.Dao
{
  
    public class SugarDao
    {
        private SugarDao()
        {

        }
        public static SQLiteSugar.SqlSugarClient GetInstance()
        {
            string connection = "DataSource=" + System.AppDomain.CurrentDomain.BaseDirectory + "database\\LkBarCode.s3db"; ; //这里可以动态根据cookies或session实现多库切换
            return new SQLiteSugar.SqlSugarClient(connection);
        }
    }

    public class SugarDaoM
    {
        private SugarDaoM()
        {

        }
        public static SqlSugar.SqlSugarClient GetInstance()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ToString();
            return new SqlSugar.SqlSugarClient(connection);
        }
    }
}

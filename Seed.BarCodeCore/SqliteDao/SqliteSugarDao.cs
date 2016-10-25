using SQLiteSugar;

namespace Seed.BarCodeCore.SqliteDao
{
    public class SugarDao
    {
         private SugarDao()
        {

        }
        public static SQLiteSugar.SqlSugarClient GetInstance()
        {
            string connection = "DataSource=" + System.AppDomain.CurrentDomain.BaseDirectory + "database\\LkBarCode.s3db"; ; //这里可以动态根据cookies或session实现多库切换
            return new SqlSugarClient(connection);
        }
    }
}

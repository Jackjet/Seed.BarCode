using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;
using SqlSugar;
using Seed.BarCodeCore.Dao;
using Seed.BarCodeCore.Models;

namespace Seed.BarCodeCore.Resposity
{
    public class SqlResposity:IResposity
    {
        public bool IsAnySmlCode(string code)
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<Product>().Any(it => it.SmlCode == code);
            }
        }

        public bool IsAnyBigCode(string code)
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<Product>().Any(it => it.SmlCode == code);
            }
        }

        public void InsertList<T>(List<T> t) where T : class
        {
            using (var db = SugarDao.GetInstance())
            {
                db.SqlBulkCopy(t);
            }
        }

        public int TodayBigCodeCount()
        {
            using (var db = SugarDao.GetInstance())
            {
                return
                db.Queryable<Products>().Select("distinct BigCode")
                    .Where("datediff(day,ProductTime,getdate())=0").ToList()
                    .Count();
  
            }
        }
    }
}

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
                return db.Queryable<Product>().Any(it => it.BigCode == code);
            }
        }

        public void InsertList<T>(List<T> t) where T : class
        {
            using (var db = SugarDao.GetInstance())
            {
                db.SqlBulkCopy(t);
            }
        }

        public int TodayBigCodeCount(string productLine)
        {
            using (var db = SugarDao.GetInstance())
            {
                return
                db.Queryable<Products>().Select("distinct BigCode")
                    .Where("datediff(day,ProductTime,getdate())=0").ToList()
                    .Count();
  
            }
        }

        public int LastUpdateInfo(string productLine)
        {
            using (var db = SugarDao.GetInstance())
            {
                Products code =
                      db.Queryable<Products>()
                          .Where(it => it.ProductLine == productLine)
                          .OrderBy("Id desc")
                          .FirstOrDefault();
                if (code != null)
                {
                    return Convert.ToInt32(code.Status);
                }
                else
                {
                    return 0;
                }
            }
        }


        public int LastUpdateId<T>(string productLine) where T:class,IId,IService,new()
        {
            using (var db = SugarDao.GetInstance())
            {
                T code =  db.Queryable<T>()
                          .Where(it => it.ProductLine == productLine)
                          .OrderBy("Id desc")
                          .FirstOrDefault();
                if (code != null)
                {
                    return Convert.ToInt32(code.Status);
                }
                else
                {
                    return 0;
                }
            }
        }
        public T LastProduct<T>() where T : new()
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<T>().OrderBy("Id desc").FirstOrDefault();
            }
        }
        public void UpdateCount(int count)
        {
            
        }
    }
}

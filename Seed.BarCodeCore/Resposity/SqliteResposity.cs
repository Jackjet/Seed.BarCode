using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;
using Seed.BarCodeCore.Models;
using Seed.BarCodeCore.SqliteDao;
using SQLiteSugar;

namespace Seed.BarCodeCore.Resposity
{
    public class SqliteResposity:IResposity
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
            string day = string.Format("{0:yyyyMMdd}", DateTime.Now);
            using (var db = SugarDao.GetInstance())
            {
                // 今天已包装件数
                ProductCount pc = db.Queryable<ProductCount>().Where(it => it.Days == day).FirstOrDefault();
                if (pc != null)
                {
                    return pc.Counts;
                }
                else
                {
                    db.Insert(new ProductCount
                    {
                        Counts = 0,
                        Days = day
                    });
                    return 0;
                }
            }
        }
    }
}

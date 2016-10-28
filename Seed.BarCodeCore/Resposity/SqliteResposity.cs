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
               // db.SqlBulkCopy(t);
                db.InsertRange(t);
            }
        }

        public int TodayBigCodeCount(string productLine)
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


        /// <summary>
        /// 上传条码数据
        /// 2016-10-28
        /// </summary>
        /// <param name="maxId"></param>
        /// <returns></returns>
        public List<Products> CodeUpdate(int maxId)
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<Product>().Where(it => it.Id > maxId).OrderBy("Id")
                    .Take(50000).ToList()
                .Select(it => new Products
                {
                    BigCode = it.BigCode,
                    SmlCode = it.SmlCode,
                    Batch = it.Batch,
                    ProductName = it.ProductName,
                    Specification= it.Specification,
                    ProductLine = it.ProductLine,
                    ProductTime=it.ProductTime,
                    Status = it.Id.ObjToString()
                }).ToList();
            }
        }

        /// <summary>
        /// 上传仓库出库数据
        /// 2016-10-28
        /// </summary>
        /// <param name="maxId">上传之前的最大Id</param>
        public List<Stores> StoreUpdate(int maxId)
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<Store>().Where(it => it.Id > maxId).OrderBy("Id").ToList()
                    .Select(it => new Stores
                    {
                        OrderInfo=it.OrderInfo,
                        BigCode=it.BigCode,
                        CreateTime=it.CreateTime,
                        Status=it.Id.ToString()
                    }).ToList();
            }
        }

        public List<Sales> SaleUpdate(int maxId)
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<Sale>().Where(it => it.Id > maxId).OrderBy("Id").ToList()
                    .Select(it => new Sales
                    {
                        OrderInfo = it.OrderInfo,
                        SaleInfo=it.SaleInfo,
                        CreateTime = it.CreateTime,
                        Status = it.Id.ToString()
                    }).ToList();
            }
        }

        public void UpdateCount(int count)
        {
            var day = string.Format("{0:yyyyMMdd}", DateTime.Now);
            using (var db = SugarDao.GetInstance())
            {
                db.Update<ProductCount>(new { Counts = count }, it => it.Days == day);
            }
           
        }

        public T LastProduct<T>() where T:new()
        {
            using (var db = SugarDao.GetInstance())
            {
                var str = db.Queryable<Product>().OrderBy("Id desc").FirstOrDefault();
                return db.Queryable<T>().OrderBy("Id desc").FirstOrDefault();               
            }
        }
    }
}

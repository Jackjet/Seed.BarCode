using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SqliteSugar;
using Seed.BarCodeStore.Dao;
using Seed.StockOutScan.Models;

namespace Seed.BarCodeStore.Reposities
{
    public class NcHandSaleInfoResposities
    {


        /// <summary>
        /// 每次就上传5万条记录吧
        /// </summary>
        /// <param name="maxId"></param>
        /// <returns></returns>
        public List<NcSaleInfo> Update(int maxId)
        {
            using (var db = SugarDao.GetInstance())
            {
                return db.Queryable<NcHandSaleInfo>().Where(it => it.Id > maxId).OrderBy("Id")
                    .Take(50000).ToList()
                .Select(it => new NcSaleInfo
                {
                    caseCode = it.BigCode,
                    SaleId = it.SaleOrder,
                    CreateTime=it.CreateTime,
                    Status = it.Id.ObjToString()
                }).ToList();
            }
        }

 


    }
}

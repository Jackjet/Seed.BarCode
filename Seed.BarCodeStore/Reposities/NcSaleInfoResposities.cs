using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SqlSugar;
using Seed.BarCodeStore.MsDao;
using Seed.StockOutScan.Models;

namespace Seed.BarCodeStore.Reposities
{
    public class NcSaleInfoResposities
    {
 
        public int LastUpdateInfo()
        {
            using (var db = SugarDao.GetInstance())
            {
              NcSaleInfo  code=
                    db.Queryable<NcSaleInfo>()
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


        public void InsertCodes(List<NcSaleInfo> list)
        {
            using (var db = SugarDao.GetInstance())
            {
                db.SqlBulkCopy(list);
            }
        }

        public void InsertCodes(List<NcSaleBase> list)
        {
            using (var db = SugarDao.GetInstance())
            {
                db.SqlBulkCopy(list);
            }
        }
    }
}

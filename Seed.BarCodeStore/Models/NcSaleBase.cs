using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.StockOutScan.Models
{
    public class NcSaleBase
    {
        public int Id { get; set; }
        public string SaleId {get;set;}

        public string SaleInfo {get;set;}


        public DateTime CreateTime {get;set;}

        public string Gid { get; set; }

        public string Remark { get; set; }

        public NcSaleBase()
        {
            Gid = Guid.NewGuid().ToString();
        }
    }
}

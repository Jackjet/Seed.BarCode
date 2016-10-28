using System;


namespace Seed.StockOutScan.Models
{
    public class NcSaleInfo
    {
        public string caseCode {get;set;}

        public string SaleId {get;set;}

        public DateTime CreateTime {get;set;}

        public string Gid { get; set; }

        public string Status { get; set; }

        public NcSaleInfo()
        {
            Gid = Guid.NewGuid().ToString();
        }
    }
}

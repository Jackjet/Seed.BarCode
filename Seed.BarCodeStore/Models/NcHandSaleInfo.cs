using System;


namespace Seed.StockOutScan.Models
{
    /// <summary>
    ///  NcCode 123
    /// </summary>
    public class NcHandSaleInfo
    {
        public int Id { get; set; }
        public string BigCode {get;set;}

        public string SaleOrder {get;set;}

        public DateTime CreateTime {get;set;}

        public NcHandSaleInfo()
        {
            CreateTime = DateTime.Now;
        }
    }
}

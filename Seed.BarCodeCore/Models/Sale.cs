using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;

namespace Seed.BarCodeCore.Models
{
    public class Sale:IId
    {
        public int Id { get; set; }
        public string OrderInfo { get; set; }

        public string SaleInfo { get; set; }
        public DateTime CreateTime { get; set; }

         public Sale()
        {
            CreateTime = DateTime.Now;
        }
    }
}

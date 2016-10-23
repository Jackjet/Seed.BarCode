using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.BarCodeCore.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string OrderInfo { get; set; }
        public string BigCode { get; set; }
        public DateTime CreateTime { get; set; }

         public Store()
        {
            CreateTime = DateTime.Now;
        }
    }
}

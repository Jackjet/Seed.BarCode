using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;

namespace Seed.BarCodeCore.Models
{
    public class Products:Product,IService
    {
        public string Gid { get; set; }

        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;

namespace Seed.BarCodeCore.Models
{
    public class Product:IProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Batch { get; set; }
        public string BigCode { get; set; }
        public string SmlCode { get; set; }
        public string Specification { get; set; }
        public string ProductLine { get; set; }
        public DateTime ProductTime { get; set; }
     
    }
}

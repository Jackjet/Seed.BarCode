using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.BarCodeCore.Models
{
    public class SystemConfig
    {
        public string SoundType { get; set; }
        public int BigCodeLen { get;set; }
        public int SmlCodeLen { get;set; }
        public string CodeType { get; set; }
        public string ProductLine { get; set; }
        public string StoreType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.BarCodeCore.Interface
{
    public interface IProductConfig
    {
        string Specification { get; set; }
        DateTime ProductTime { get; set; }
    }
}

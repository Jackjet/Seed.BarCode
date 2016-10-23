using System;
using System.Collections.Generic;

namespace Seed.BarCodeCore.Interface
{
    public interface IProduct:ICode
    {
        string Specification { get; set; }
        string ProductLine { get; set; }
        DateTime ProductTime { get; set; }
    }
}

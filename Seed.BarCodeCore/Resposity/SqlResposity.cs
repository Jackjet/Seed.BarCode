using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;

namespace Seed.BarCodeCore.Resposity
{
    public class SqlResposity:IResposity
    {
        public bool IsAnySmlCode(string code)
        {
            return true;
        }

        public bool IsAnyBigCode(string code)
        {
            return true;
        }

        public void InsertList<T>(List<T> t) where T : class
        {
            
        }
    }
}

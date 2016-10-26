using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.BarCodeCore.Interface
{
    public interface IResposity
    {
        bool IsAnySmlCode(string code);
        bool IsAnyBigCode(string code);

        void InsertList<T>(List<T> t) where T : class;

        int TodayBigCodeCount(string productLine);

        void UpdateCount(int count);
    }
}

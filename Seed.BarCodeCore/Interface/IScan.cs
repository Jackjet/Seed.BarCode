using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.BarCodeCore.Interface
{
    public interface IScan
    {
        void ScanBarCode(string code);

        void Log(string str);
        bool IsBigCode(string code, int len);
        bool IsBagFull(int countNow, int countDefault);


        bool IsAnySmlCodeInList(string code);
     
    }
}

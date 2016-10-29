using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;

namespace Seed.BarCodeCore.Models
{
    public class Stores:Store,IService
    {

        public string Status { get; set; }

        public string Gid { get; set; }

        public Stores()
        {
            Gid = Guid.NewGuid().ToString();
        }

    }
}

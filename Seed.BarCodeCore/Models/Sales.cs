using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seed.BarCodeCore.Interface;

namespace Seed.BarCodeCore.Models
{
    public class Sales:Sale,IService
    {

        
        public string Status { get; set; }

        public string Gid { get; set; }



        public Sales()
        {
            Gid = Guid.NewGuid().ToString();
        }
    }
}

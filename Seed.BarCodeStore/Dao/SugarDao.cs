﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqliteSugar;

namespace Seed.BarCodeStore.Dao
{
    /// <summary>
    /// SqlSugar
    /// </summary>
    public class SugarDao
    {
        //禁止实例化
        private SugarDao() { 

        }
        public static SqlSugarClient GetInstance()
        {
            string connection = "DataSource=" + System.AppDomain.CurrentDomain.BaseDirectory + "database\\NcBarCode.s3db"; ; //这里可以动态根据cookies或session实现多库切换
            return new SqlSugarClient(connection);
        }
    }
}
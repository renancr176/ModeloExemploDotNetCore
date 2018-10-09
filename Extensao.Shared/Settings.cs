using System;
using System.Collections.Generic;
using System.Text;

namespace Extensao.Shared
{
    public static class Settings
    {
        public static string ConnectionString = @"Data Source=CBM-SQLSRVTESTE;Initial Catalog=Extensao;Persist Security Info=True;User ID=ui_cn_api_extensao;Password=MmDPUH2PbyOW;MultipleActiveResultSets=True";
        public static string MongoDBConnectionString = @"mongodb://us_cn_extensao:uYfPu^pQ4;k]T^*y-{FCVp~sC.s8(pnG@10.1.1.67:27017/Extensao";
        public static string MongoDBDataBase = "Extensao";
    }
}

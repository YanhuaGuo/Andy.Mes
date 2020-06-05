using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Core.Configuration
{
    public class SystemConfig
    {
        public const string Position = "SysConfig";


        public DbConfig DbConfig { get; set; }
        public Redis Redis { get; set; }

        public static SystemConfig Config { get; set; }
    }

    public class DbConfig
    {
        public string Provider { get; set; }

        public string ConnectionString { get; set; }
    }

    public class Redis
    {
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Core.Configuration
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SystemConfig
    {
        public static string ProjectNamePre { get { return "Andy.Mes"; } }

        public const string Position = "SysConfig";

        /// <summary>
        /// 数据库配置
        /// </summary>
        public DbConfig DbConfig { get; set; }
        
        /// <summary>
        /// redis配置
        /// </summary>
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

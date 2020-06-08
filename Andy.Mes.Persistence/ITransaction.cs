using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Andy.Mes.Persistence
{
    public interface ITransaction : IDisposable
    {
        /// <summary>
        /// 开始事物
        /// </summary>
        ITransaction BeginTransaction();

        /// <summary>
        /// 开始事物
        /// 注:自定义事物级别
        /// </summary>
        /// <param name="isolationLevel">事物级别</param>
        ITransaction BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// 提交事物
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚事物
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// 结束事物
        /// </summary>
        /// <returns></returns>
        (bool Success, Exception ex) EndTransaction();
    }
}

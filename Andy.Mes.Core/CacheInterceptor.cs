using Castle.DynamicProxy;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andy.Mes.Core
{
    public class CacheInterceptor : IInterceptor
    {
        private readonly ILogger Logger = null;
        public CacheInterceptor(ILogger _logger)
        {
            Logger = _logger;
        }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Calling method {0} with parameters {1}... ",
                  invocation.Method.Name,
                  string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            Console.WriteLine("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}

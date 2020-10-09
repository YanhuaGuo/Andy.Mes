using NUnit.Framework;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Application
{
    public class UnitTest : TestBase
    {
      

        [Test]
        public void Test1()
        {
            var app = _autofacServiceProvider.GetService<IStaffService>();
            Assert.IsTrue(app != null);
        }
    }
}

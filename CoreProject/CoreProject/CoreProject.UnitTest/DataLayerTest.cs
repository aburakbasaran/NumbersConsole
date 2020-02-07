using CoreProject.DataLayer;
using CoreProject.Entity.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using Xunit;

namespace CoreProject.UnitTest
{
    public class DataLayerTest
    {
        [Fact]
        public void Test1()
        {
            var context = new CoreProjectContext<CoreProjectContext>("");
            var dtLayer = new DemoDataLayer(context);
            dtLayer.DenemeWOCache();
        }
    }
}

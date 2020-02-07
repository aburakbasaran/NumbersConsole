using CoreProject.DataLayerContracts;
using CoreProject.Entity.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;

namespace CoreProject.DataLayer
{
    public class DemoDataLayer:IDemoDataLayer
    {

        private readonly CoreProjectContext _context;
        IMemoryCache _memoryCache;

        public DemoDataLayer(CoreProjectContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;

        }

        public DemoDataLayer(CoreProjectContext context)
        {
            _context = context;
        }
        public void Deneme()
        {
                var seko= _context.City.ToList();
            _memoryCache.Set("Cityler", seko, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddDays(20),
                Priority = CacheItemPriority.Normal
            });
        
        }

        public void DenemeWOCache()
        {
            var seko = _context.City.ToList();
            _memoryCache.Set("Cityler", seko, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddDays(20),
                Priority = CacheItemPriority.Normal
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.BusinessContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CoreProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoBusiness business;
        IMemoryCache _memoryCache;

        public DemoController(IDemoBusiness business, IMemoryCache memoryCache)
        {
            this.business = business;
            this._memoryCache = memoryCache;
        }

        [HttpGet, Route("get")]
        public IActionResult Get()
        {
            business.Deneme();
            var deneme = _memoryCache.Get("Cityler");
            return new JsonResult("");
        }


        [HttpGet, Route("getCache")]
        public IActionResult getCache()
        {
            var deneme = _memoryCache.Get("Cityler");
            return new JsonResult("");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SanaStore.Dal.Models;

namespace SanaStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Settings")]
    public class SettingsController : BaseController
    {
        public SettingsController(IConfiguration configuration) : base(configuration)
        {

        }
        // GET: api/Settings
        [HttpGet]
        public Settings Get()
        {
            return new Settings
            {
                SourceType = GetSessionSourceType()
            };
        }
        
        // POST: api/Settings
        [HttpPost]
        public DmResult Post([FromBody]Settings settings)
        {
            SetSessionSourceType(settings.SourceType);
            return new DmResult
            {
                Success = true,
                Id = 0
            };
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SanaStore.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SanaStore.Controllers
{
    public class BaseController : Controller
    {
        private static string sourceTypeSessId = "com.marcohern.sana.sourceType";

        protected IConfiguration Configuration;

        public BaseController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        protected SanaSourceSourceType GetSessionSourceType()
        {
            if (!HttpContext.Session.Keys.Contains(sourceTypeSessId))
            {
                HttpContext.Session.SetInt32(sourceTypeSessId, (int)SanaSourceSourceType.SqlServer);
            }
            return (SanaSourceSourceType)this.HttpContext.Session.GetInt32(sourceTypeSessId);
        }

        protected void SetSessionSourceType(SanaSourceSourceType sourceType)
        {
            HttpContext.Session.SetInt32(sourceTypeSessId, (int)sourceType);
        }

        protected ISanaStoreContext GetDatabase()
        {
            var sourceType = GetSessionSourceType();
            switch(sourceType)
            {
                case SanaSourceSourceType.SqlServer:
                    return new SqlServerSanaStoreContext(Configuration.GetConnectionString("DefaultConnection"));
                case SanaSourceSourceType.InMemory:
                    return new InMemorySanaStoreContext();
                default:
                    return null;
            }
        }
    }
}

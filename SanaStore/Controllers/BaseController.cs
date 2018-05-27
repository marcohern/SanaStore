using Microsoft.AspNetCore.Mvc;
using SanaStore.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SanaStore.Dal.Impl;

namespace SanaStore.Controllers
{
    public class BaseController : Controller
    {
        private const string sourceTypeSessId = "com.marcohern.sana.sourceType";

        protected IConfiguration Configuration;
        protected IServiceProvider ServiceProvider;

        public BaseController(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            this.Configuration = configuration;
            this.ServiceProvider = serviceProvider;
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
                    return (ISanaStoreContext)ServiceProvider.GetService(typeof(SqlServerSanaStoreContext));
                case SanaSourceSourceType.InMemory:
                    return (ISanaStoreContext)ServiceProvider.GetService(typeof(InMemorySanaStoreContext));
                default:
                    return null;
            }
        }
    }
}

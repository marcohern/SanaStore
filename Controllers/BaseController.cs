using Microsoft.AspNetCore.Mvc;
using SanaStore.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SanaStore.Controllers
{
    public class BaseController : Controller
    {
        private static string sourceTypeSessId = "com.marcohern.sana.sourceType";
        public SanaSourceSourceType GetSessionSourceType()
        {
            if (!HttpContext.Session.Keys.Contains(sourceTypeSessId))
            {
                HttpContext.Session.SetInt32(sourceTypeSessId, (int)SanaSourceSourceType.SqlServer);
            }
            return (SanaSourceSourceType)this.HttpContext.Session.GetInt32(sourceTypeSessId);
        }

        public void SetSessionSourceType(SanaSourceSourceType sourceType)
        {
            HttpContext.Session.SetInt32(sourceTypeSessId, (int)sourceType);
        }


        protected SanaStoreContext GetDatabase()
        {
            return SanaStoreDatabase.Get(GetSessionSourceType());
        }
    }
}

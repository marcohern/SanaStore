using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanaStore.Dal.Models;

namespace SanaStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : BaseController
    {
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            using(var db = GetDatabase())
            {
                return db.Categories.ToList();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            using (var db = GetDatabase())
            {
                return db.Categories.Where(c => c.Id == id).First();
            }
        }
        
        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

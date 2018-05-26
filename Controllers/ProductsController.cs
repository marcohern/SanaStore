using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanaStore.Dal;
using SanaStore.Dal.Models;

namespace SanaStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : BaseController
    {
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (var db = GetDatabase())
            {
                return db.Products.ToList();
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            using (var db = GetDatabase())
            {
                return db.Products.Where(p => p.Id == id).First();
            }
        }
        
        // POST: api/Products
        [HttpPost]
        public DmResult Post([FromBody]Product product)
        {
            using (var db = GetDatabase())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return new DmResult
                {
                    Success = true,
                    Id = product.Id
                };
            }
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public DmResult Put(int id, [FromBody]Product product)
        {
            var db = GetDatabase();
            product.Id = id;
            db.Products.Update(product);
            db.SaveChanges();
            return new DmResult
            {
                Success = true,
                Id = product.Id
            };
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public DmResult Delete(int id)
        {
            using (var db = GetDatabase())
            {
                var product = db.Products.Where(p => p.Id == id).First();
                db.Products.Remove(product);
                db.SaveChanges();
                return new DmResult
                {
                    Success = true,
                    Id = id
                };
            }
        }
    }
}

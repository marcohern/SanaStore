using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SanaStore.Dal;
using SanaStore.Dal.Models;

namespace SanaStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : BaseController
    {
        public ProductsController(IConfiguration configuration):base(configuration)
        {

        }
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
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            using (var db = GetDatabase())
            {
                return db.Products.Where(p => p.Id == id).Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).First();
            }
        }
        
        // POST: api/Products
        [HttpPost]
        public DmResult Post([FromBody]ProductExtended cp)
        {
            using (var db = GetDatabase())
            {
                db.Products.Add(cp.Product);
                cp.Categories.ForEach(c => db.ProductCategories.Add(new ProductCategory { ProductId = cp.Product.Id, CategoryId = c.Id }));
                db.SaveChanges();
                return new DmResult
                {
                    Success = true,
                    Id = cp.Product.Id
                };
            }
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public DmResult Put(int id, [FromBody]ProductExtended cp)
        {
            using (var db = GetDatabase())
            {
                var categories = db.ProductCategories.Where(pc => pc.ProductId == id).ToList();
                db.ProductCategories.RemoveRange(categories);
                db.SaveChanges();

                cp.Product.Id = id;
                db.Products.Update(cp.Product);
                cp.Categories.ForEach(c => db.ProductCategories.Add(new ProductCategory { ProductId = cp.Product.Id, CategoryId = c.Id }));
                db.SaveChanges();
                return new DmResult
                {
                    Success = true,
                    Id = cp.Product.Id
                };
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public DmResult Delete(int id)
        {
            using (var db = GetDatabase())
            {
                var product = db.Products.Where(p => p.Id == id).First();
                var categories = db.ProductCategories.Where(pc => pc.ProductId == id).ToList();
                db.ProductCategories.RemoveRange(categories);
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

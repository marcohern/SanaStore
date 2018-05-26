using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanaStore.Dal;
using SanaStore.Dal.Models;

namespace SanaStore.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : BaseController
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public Order GetCustomers()
        {
            var db = SanaStoreDatabase.Get(SanaSourceSourceType.InMemory);
            var item = db.Orders.Where(o => o.Id == 1).Include(o => o.OrderDetails).ThenInclude(od => od.Product).FirstOrDefault();
            return item;
        }

        [HttpGet("[action]")]
        public DmResult SetInMomory()
        {
            SetSessionSourceType(SanaSourceSourceType.InMemory);
            return new DmResult { Id = 0, Success = true };
        }

        [HttpGet("[action]")]
        public DmResult SetSqlServer()
        {
            SetSessionSourceType(SanaSourceSourceType.SqlServer);
            return new DmResult { Id = 0, Success = true };
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}

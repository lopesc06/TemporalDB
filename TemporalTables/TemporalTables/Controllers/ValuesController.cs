using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemporalTables.Entities;

namespace TemporalTables.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        private HistoricalTestContext _context;

        public ValuesController(HistoricalTestContext context)
        {
            _context = context;
        }


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.Include(p=>p.Details));
        }

        // POST api/values
        [HttpGet("a")]
        public IActionResult gett()
        {
            var p1 = new Product { Name = "Product 5" };
            p1.Details = new List<ProductDetail>() { new ProductDetail { Name = "Detail 1", Value = "Value 1" } };
            _context.Products.Add(p1);
            var x = _context.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpPut("xdxd")]
        public IActionResult Putin()
        {
            var p1 = _context.Products.Find(5);
            p1.Name = "asdhasjkdasd";
            var d1 = _context.ProductDetails.Find(5);
            d1.Value = "asdasdasd";
            _context.SaveChanges();
            return Ok();
        }
    }
}

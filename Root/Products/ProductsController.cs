using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restore.Data;

namespace restore.Root.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _db;

        public ProductsController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string brands, int? minPrice, int? maxPrice, 
            int? minScreen, int? maxScreen, string capacity, string colours, string os, string features)
        {
            return Ok(await _db.Products.ToListAsync());
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug)
        {
            var product = await _db.Products.SingleOrDefaultAsync(p => p.Slug == slug);

            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}

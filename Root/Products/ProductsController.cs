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
            int? minScreen, int? maxScreen, string capacity, string colors, string os, string features)
        {
            var Brands = string.IsNullOrEmpty(brands) ? new List<string>() : brands.Split('|').ToList();
            var Colors = string.IsNullOrEmpty(colors) ? new List<string>() : colors.Split('|').ToList();
            var OS = string.IsNullOrEmpty(os) ? new List<string>() : os.Split('|').ToList();
            var Features = string.IsNullOrEmpty(features) ? new List<string>() : features.Split('|').ToList();
            var CapacityStr = string.IsNullOrEmpty(capacity) ? new List<string>() : capacity.Split('|').ToList();
            var Capacity = new List<int>();
            foreach (var c in CapacityStr)
            {
                Capacity.Add(Convert.ToInt32(c, 10));
            }

            return Ok(await _db.Products
                .Where(x => Brands.Any() == false || Brands.Contains(x.Brand.Name))
                .Where(x => OS.Any() == false || OS.Contains(x.OS.Name))
                .Where(x => minPrice.HasValue == false || x.ProductVariants.Any(v => v.Price >= minPrice.Value))
                .Where(x => maxPrice.HasValue == false || x.ProductVariants.Any(v => v.Price <= maxPrice.Value))
                .Where(x => minScreen.HasValue == false || x.ScreenSize >= Convert.ToDecimal(minScreen.Value))
                .Where(x => maxScreen.HasValue == false || x.ScreenSize <= Convert.ToDecimal(maxScreen.Value))
                .Where(x => Capacity.Any() == false || x.ProductVariants.Any(v => Capacity.Contains(v.Storage.Capacity)))
                .Where(x => Colors.Any() == false || x.ProductVariants.Any(v => Colors.Contains(v.Color.Name)))
                .Where(x => Features.Any() == false || Features.All(
                    f => x.ProductFeatures.Any(pf => pf.Feature.Name == f)))
                .Select(x => new ProductListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    Thumbnail = x.Thumbnail,
                    Slug = x.Slug,
                    Price = x.ProductVariants.Select(p => p.Price).First()
                })
                .ToListAsync());
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restore.Data;

namespace restore.Root.Filters
{
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        private readonly ApplicationContext _db;

        public FiltersController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands = await _db.Brands.Select(x => x.Name).ToListAsync();
            var storage = await _db.Storage.Select(x => x.Capacity).ToListAsync();
            var os = await _db.OS.Select(x => x.Name).ToListAsync();
            var colors = await _db.Colors.Select(x => x.Name).ToListAsync();
            var features = await _db.Features.Select(x => x.Name).ToListAsync();

            return Ok(new FiltersModel
            {
                Brands = brands,
                OS = os,
                Capacity = storage,
                Colors = colors,
                Features = features
            });
        }
    }
}

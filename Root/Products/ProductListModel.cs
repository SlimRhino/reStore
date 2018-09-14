using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restore.Root.Products
{
    public class ProductListModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }
        public decimal Price { get; set; }
    }
}

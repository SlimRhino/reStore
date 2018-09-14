
using System.Collections.Generic;


namespace restore.Root.Filters
{
    public class FiltersModel
    {
        public IEnumerable<string> Brands { get; set; }
        public IEnumerable<string> Colors { get; set; }
        public IEnumerable<string> OS { get; set; }
        public IEnumerable<string> Features { get; set; }
        public IEnumerable<int> Capacity { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // zaten bu var

        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public List<string> Collection { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool Hot { get; set; }
        public string Discount { get; set; }
        public int Stock { get; set; }
        public bool New { get; set; }
        public int Rating { get; set; }
        public List<string> Tags { get; set; }
        public List<Variant> Variants { get; set; }
        public List<Image> Images { get; set; }
    }
}

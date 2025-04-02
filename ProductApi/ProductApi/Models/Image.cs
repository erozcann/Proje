using System.Collections.Generic;

namespace ProductApi.Models
{
    public class Image
    {
        public int Image_Id { get; set; }
        public int Id { get; set; }
        public string Alt { get; set; }
        public string Src { get; set; }
        public List<int> Variant_Id { get; set; }
    }
}

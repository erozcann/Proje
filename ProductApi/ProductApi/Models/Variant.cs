namespace ProductApi.Models
{
    public class Variant
    {
        public int Variant_Id { get; set; }
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Image_Id { get; set; }
    }
}

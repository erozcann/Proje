using ProductApi.Models;
using System.Text.Json;

namespace ProductApi.Data
{
    public static class ProductSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "products.json");
                if (!File.Exists(jsonPath)) return;

                var jsonData = File.ReadAllText(jsonPath);

                var wrapper = JsonSerializer.Deserialize<ProductWrapper>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (wrapper?.Data != null)
                {
                    // Bu satır önemli!
                    foreach (var item in wrapper.Data)
                    {
                        item.Id = 0; // EF otomatik versin
                        item.Images = null;
                        item.Variants = null;
                    }

                    context.Products.AddRange(wrapper.Data);
                    context.SaveChanges();
                }

            }
        }
    }
}

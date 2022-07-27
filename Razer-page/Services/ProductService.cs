using Razer_page.Model;

namespace Razer_page.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        
        public void LoadProduct()
        {
            products.Clear();

            products.Add(new Product()
            {
                Id = 1,
                Name = "iphone",
                Description = "day la iphone",
                Price = 1000

            });
            products.Add(new Product()
            {
                Id = 2,
                Name = "Samsung",
                Description = "day la Samsung",
                Price = 1000

            });
            products.Add(new Product()
            {
                Id = 3,
                Name = "Xaomi",
                Description = "day la Xaomi",
                Price = 1000

            });
        }

        public ProductService()
        {
            LoadProduct();
        }

        public Product Find(int Id)
        {
            var qr = from p in products
                     where p.Id == Id
                     select p;

            return qr.FirstOrDefault();
        }

        public List<Product> AllProduct() => products;
    }
}

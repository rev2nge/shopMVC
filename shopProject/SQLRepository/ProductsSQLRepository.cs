using shopProject.Interface;
using shopProject.Models;

namespace shopProject.SQLRepository
{
    public class ProductsSQLRepository : IProductRepository
    {
        private readonly ApplicationContext context;
        public ProductsSQLRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public Product Create(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            var products = context.Product.Attach(product);
            products.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return product;
        }

        public Product Delete(int Id)
        {
            Product product = context.Product.Find(Id);
            if (product != null)
            {
                context.Product.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetProduct()
        {
            return context.Product;
        }

        public Product GetProductByID(int? Id)
        {
            return context.Product.Find(Id);
        }
    }
}

using e_commerce.ApplicationContextName;
using e_commerce.Entity;
using e_commerce.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace e_commerce.Repository
{
    public class Product : IProduct
    {
        private readonly IApplicationContext _context;

        public Product(IApplicationContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            var resp= await _context.Products.ToListAsync();
            return resp;
        }
        public async Task<ProductEntity> GetSingleProduct(int id)
        {
            var resp = await _context.Products.Where(x=>x.Id==id).FirstOrDefaultAsync();
            return resp;
        }
        public async Task<int> CreateProduct(CreateProductRequest productRequest)
        {
            var product = new ProductEntity();
            product.Name=productRequest.Name;
            product.Description=productRequest.Description;
            product.Price=productRequest.Price;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsyncs();
            return product.Id;
        }
    }
}

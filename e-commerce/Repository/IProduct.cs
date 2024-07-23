using e_commerce.Entity;
using e_commerce.Model;

namespace e_commerce.Repository
{
    public interface IProduct
    {
        Task<int> CreateProduct(CreateProductRequest productRequest);
        Task<IEnumerable<ProductEntity>> GetAllProducts();
        Task<ProductEntity> GetSingleProduct(int id);
    }
}

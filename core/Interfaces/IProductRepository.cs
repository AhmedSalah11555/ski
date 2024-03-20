using System.Collections.Generic;
using core.Entities;

namespace core.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductById (int id);
        IReadOnlyList <Product> GetProducts();
        IReadOnlyList <ProductBrand> GetProductBrands();
        IReadOnlyList <ProductType> GetProductTypes();
        
    }
}
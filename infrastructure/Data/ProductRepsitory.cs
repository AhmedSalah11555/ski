using System.Collections.Generic;
using System.Linq;
using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class ProductRepsitory : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepsitory(StoreContext context)
        {
            _context = context;
        }

        public IReadOnlyList<ProductBrand> GetProductBrands()
        {
           return _context.ProductBrands.ToList();
        }

        public Product GetProductById(int id)
        {
           return _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .FirstOrDefault(p=>p.Id==id);
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductBrand)
            .ToList();
        }

        public IReadOnlyList<ProductType> GetProductTypes()
        {
            return _context.ProductTypes.ToList();
        }
    }
}
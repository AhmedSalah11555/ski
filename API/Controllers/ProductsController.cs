using System.Collections.Generic;
using System.Linq;
using core.Entities;
using core.Interfaces;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _Repo;
      
        public ProductsController(IProductRepository Repo)
        {
            _Repo = Repo;
            
        }


        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products=_Repo.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _Repo.GetProductById(id);
        }
        [HttpGet("brands")]
        public ActionResult<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return Ok(_Repo.GetProductBrands());
        }
          [HttpGet("types")]
        public ActionResult<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return Ok(_Repo.GetProductTypes());
        }
    }
}
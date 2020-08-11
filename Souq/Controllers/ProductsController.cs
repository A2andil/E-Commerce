using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Souq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IGenericRepository<Product> _products;
        public ProductsController(IProductRepository repo, IGenericRepository<Product> products)
        {
            _repo = repo;
            _products = products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _products.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts()
        {
            var products = await _products.ListAllAsync();
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetBrands()
        {
            return Ok(await _repo.GetProductBrandAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<ProductBrand>> GetTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}
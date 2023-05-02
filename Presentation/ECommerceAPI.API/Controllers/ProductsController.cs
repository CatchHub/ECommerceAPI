using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            // It's just an example created to check if the repository design pattern which i build works.
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(),Name = "Product 1" , CreatedDate = DateTime.UtcNow,Price=100,Stock=10},
            //    new() { Id = Guid.NewGuid(),Name = "Product 2" , CreatedDate = DateTime.UtcNow,Price=200,Stock=20},
            //    new() { Id = Guid.NewGuid(),Name = "Product 3" , CreatedDate = DateTime.UtcNow,Price=300,Stock=30},
            //});
            Product p1 = await _productReadRepository.GetByIdAsync("0d8fb717-e585-4432-a6b8-745f0e24795d");// product 3 
            p1.Name = "Sample";            
            Product p2 = await _productReadRepository.GetByIdAsync("63661482-d19e-4f8d-ba0e-1481992ccd3e", false);// product 2 
            p2.Name = "Sample";
            await _productWriteRepository.SaveAsync();
            var count = await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await this._productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}

﻿using ECommerceAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductWriteRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductWriteRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            // It's just an example created to check if the repository design pattern which i build works.
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(),Name = "Product 1" , CreatedDate = DateTime.UtcNow,Price=100,Stock=10},
                new() { Id = Guid.NewGuid(),Name = "Product 2" , CreatedDate = DateTime.UtcNow,Price=200,Stock=20},
                new() { Id = Guid.NewGuid(),Name = "Product 3" , CreatedDate = DateTime.UtcNow,Price=300,Stock=30},
            });
            var count = await _productWriteRepository.SaveAsync();
        }
    }
}

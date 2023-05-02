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

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Umut",});

            //await _orderWriteRepository.AddAsync(new() { Description = "Sample Order 1", Address = "Ankara, Turkey" , CustomerId = customerId});
            //await _orderWriteRepository.AddAsync(new() { Description = "Sample Order 2", Address = "Istanbul, Turkey", CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync(); // to check SaveChangeAsync Interceptor for CreatedDate prop

            Order order = await _orderReadRepository.GetByIdAsync("c75e0b23-bad3-49ab-985c-54104868ef45");
            order.Address = "Ankara, Turkey";
            await _orderWriteRepository.SaveAsync();            
        }


        //[HttpGet]
        //public async Task Get()
        //{
        //    // It's just an example created to check if the repository design pattern which i build works.
        //    //await _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new() { Id = Guid.NewGuid(),Name = "Product 1" , CreatedDate = DateTime.UtcNow,Price=100,Stock=10},
        //    //    new() { Id = Guid.NewGuid(),Name = "Product 2" , CreatedDate = DateTime.UtcNow,Price=200,Stock=20},
        //    //    new() { Id = Guid.NewGuid(),Name = "Product 3" , CreatedDate = DateTime.UtcNow,Price=300,Stock=30},
        //    //});
        //    //Product p1 = await _productReadRepository.GetByIdAsync("0d8fb717-e585-4432-a6b8-745f0e24795d");// product 3 
        //    //p1.Name = "Sample";            
        //    //Product p2 = await _productReadRepository.GetByIdAsync("63661482-d19e-4f8d-ba0e-1481992ccd3e", false);// product 2 
        //    //p2.Name = "Sample";
        //    //await _productWriteRepository.SaveAsync();
        //    //var count = await _productWriteRepository.SaveAsync
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await this._productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}
    }
}

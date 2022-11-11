using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionExample.Application.Repositories;
using OnionExample.Domain.Entities;
using System.Linq.Expressions;
using System.Xml;

namespace OnionExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public IActionResult GetProducts() {

            return Ok(_productReadRepository.GetAll(false));
        }

        [HttpPost]
        public async Task<IActionResult> Post() {

            //await  _productWriteRepository.AddRangeAsync(new() 
            //{
            //     new(){Id = Guid.NewGuid(),Name="Orbit",Price=100,CreatedDate = DateTime.Now,Stock=50 },
            //     new(){Id = Guid.NewGuid(),Name="Orbit",Price=100,CreatedDate = DateTime.Now,Stock=50 },
            //     new(){Id = Guid.NewGuid(),Name="Orbit",Price=100,CreatedDate = DateTime.Now,Stock=50 },
            //     new(){Id = Guid.NewGuid(),Name="Orbit",Price=100,CreatedDate = DateTime.Now,Stock=50 },

            //});
            await _productWriteRepository.AddAsync(new()
            {
                Name="Twix",
               Price = 150,
              Stock = 70
            });


           await _productWriteRepository.SaveAsync();
            return Ok();
        
        }
    }
}

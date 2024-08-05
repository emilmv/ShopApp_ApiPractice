using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAppPB301.DTOs.ProductDTOs;
using ShopAppPB301.Entities;
using ShopAppPB301.Mappers;

namespace ShopAppPB301.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public List<Product> Products = new()
        {
            new()
            {
                Id = 1,
                Name="Product1",
                Description="Description1",
                Price=19
            },
            new()
            {
                Id = 2,
                Name="Product2",
                Description="Description2",
                Price=25
            },
            new()
            {
                Id = 3,
                Name="Product3",
                Description="Description3",
                Price=30
            },
            new()
            {
                Id = 4,
                Name="Product4",
                Description="Description4",
                Price=35
            }
        };
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, Products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, existProduct);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDTO productDTO)
        {
            if (productDTO is null) return StatusCode(StatusCodes.Status400BadRequest);
            if (Products.Any(p => p.Name.Trim().ToLower() == productDTO.Name.Trim().ToLower())) return StatusCode(StatusCodes.Status400BadRequest);
            Product newProduct = new()
            {
                Id=5, //Requires database algorithm for unique ID
                Name=productDTO.Name,
                Description=productDTO.Description,
                Price=productDTO.Price,
            };
            Products.Add(ProductMapper.ProductDTOToProduct(productDTO));
            return StatusCode(StatusCodes.Status201Created, productDTO);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return StatusCode(StatusCodes.Status404NotFound);
            if (existProduct.Name.Trim().ToLower() != product.Name.Trim().ToLower() && Products.Any(p => p.Name.Trim().ToLower() == product.Name.Trim().ToLower() && p.Id != product.Id)) return StatusCode(StatusCodes.Status400BadRequest);
            existProduct.Name = product.Name;
            existProduct.Description = product.Description;
            existProduct.Price = product.Price;
            return StatusCode(StatusCodes.Status200OK, existProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return StatusCode(StatusCodes.Status404NotFound);
            Products.Remove(existProduct);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}

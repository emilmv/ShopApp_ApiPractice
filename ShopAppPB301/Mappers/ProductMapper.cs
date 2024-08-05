using ShopAppPB301.DTOs.ProductDTOs;
using ShopAppPB301.Entities;

namespace ShopAppPB301.Mappers
{
    public class ProductMapper
    {
        public static Product ProductDTOToProduct(ProductCreateDTO dto)=>new Product
        {
            Name= dto.Name,
            Description= dto.Description,
            Price= dto.Price,
        };
    }
}

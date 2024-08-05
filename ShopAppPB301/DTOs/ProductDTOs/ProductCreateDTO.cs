using System.ComponentModel.DataAnnotations;

namespace ShopAppPB301.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        [MaxLength(10)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 500)]
        public decimal Price { get; set; }
    }
}

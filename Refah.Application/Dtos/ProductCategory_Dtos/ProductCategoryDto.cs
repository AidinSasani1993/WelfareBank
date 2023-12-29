using Refah.Application.Dtos.Product_Dtos;

namespace Refah.Application.Dtos.ProductCategory_Dtos
{
    public class ProductCategoryDto
    {
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}

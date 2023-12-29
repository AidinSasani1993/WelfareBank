namespace Refah.Application.Dtos.Product_Dtos
{
    public class ProductDto
    {
        public Guid CategoryRef { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public decimal UnitePrice { get; set; }
        public string Image { get; set; }
    }
}

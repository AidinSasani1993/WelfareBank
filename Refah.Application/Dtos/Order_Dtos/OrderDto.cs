namespace Refah.Application.Dtos.Order_Dtos
{
    public class OrderDto
    {
        public Guid UserRef { get; set; }
        public double TotalAmount { get; set; }
        public bool IsCanceled { get; set; }
    }
}

namespace Refah.Application.Dtos.Order_Dtos
{
    public class CreateOrUpdateOrder
    {
        public Guid UserRef { get; set; }
        public double TotalAmount { get; set; }
        public bool? IsCanceled { get; set; }
    }
}

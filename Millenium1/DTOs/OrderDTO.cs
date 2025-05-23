namespace Millenium1.DTOs
{
    public class OrderDto
    {
        public int Orderid { get; set; }
        public int? AdministratorId { get; set; }
        public int? SewerId { get; set; }
        public int? FabricId { get; set; }
        public long ClientId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly DueDate { get; set; }
        public int? StatusOrderId { get; set; }
    }
}
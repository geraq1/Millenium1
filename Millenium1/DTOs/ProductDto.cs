namespace Millenium1.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int? EquipmentId { get; set; }
        public int CategoryId { get; set; }
        public int? FabricId { get; set; }
    }
}
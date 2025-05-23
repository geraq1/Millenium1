namespace Millenium1.DTOs
{
    public class FabricDto
    {
        public int FabricId { get; set; }
        public string FabName { get; set; } = null!;
        public decimal PricePerMeter { get; set; }
        public string? Description { get; set; }
        public string MaterialType { get; set; } = null!;
        public int? SupplierId { get; set; }
    }
}

namespace Millenium1.DTOs
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int? StatusEquipmentId { get; set; }
    }
}
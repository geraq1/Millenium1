namespace Millenium1.DTOs
{
    public class MaintenanceDto
    {
        public int MaintenanceId { get; set; }
        public int EquipmentId { get; set; }
        public DateOnly MaintenanceDate { get; set; }
        public string MaintenanceType { get; set; } = null!;
        public string? MaintenanceDescription { get; set; }
        public DateOnly? NextMaintenanceDate { get; set; }
    }
}
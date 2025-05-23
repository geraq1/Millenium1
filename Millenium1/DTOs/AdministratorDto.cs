namespace Millenium1.DTOs
{
    public class AdministratorDto
    {
        public int AdministratorId { get; set; }
        public string AdministratorFio { get; set; } = null!;
        public string? AdministratorEmail { get; set; }
        public string AdministratorPhone { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}

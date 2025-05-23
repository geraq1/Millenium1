namespace Millenium1.DTOs
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? SupplierEmail { get; set; }
        public string SupplierPhone { get; set; } = null!;
        public DateOnly? RegistrationDate { get; set; }
    }
}
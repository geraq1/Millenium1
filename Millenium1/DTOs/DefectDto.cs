namespace Millenium1.DTOs
{
    public class DefectDto
    {
        public int DefectId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; } = null!;
        public int? StatusDefectsId { get; set; }
    }
}
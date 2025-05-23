namespace Millenium1.DTOs
{
    public class RequestDto
    {
        public int Requestid { get; set; }
        public int FabricId { get; set; }
        public int Supplierid { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateOnly Startdate { get; set; }
        public DateOnly? Enddate { get; set; }
        public bool Isdone { get; set; }
    }
}
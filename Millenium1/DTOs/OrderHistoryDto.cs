namespace Millenium1.DTOs
{
    public class OrderHistoryDto
    {
        public int Histid { get; set; }
        public long Clientid { get; set; }
        public int Orderid { get; set; }
        public DateOnly Date { get; set; }
    }
}
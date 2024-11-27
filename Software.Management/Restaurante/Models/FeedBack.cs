namespace Restaurante.Models
{
    public class FeedBack
    {
        public int FeedbackId { get; set; }
        public Order? Order { get; set; }
        public string? Description { get; set; }
    }
}

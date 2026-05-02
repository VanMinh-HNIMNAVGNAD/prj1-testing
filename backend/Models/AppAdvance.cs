namespace backend.Models
{
    public class AppAdvance
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime AdvanceDate { get; set; } = DateTime.Now;
        public int RepayFromMonth { get; set; }
        public int RepayFromYear { get; set; }
        public string Status { get; set; } = "Active";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

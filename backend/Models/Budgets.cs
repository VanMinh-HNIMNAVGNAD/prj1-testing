namespace backend.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal WarningThreshold { get; set; } = 80m;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

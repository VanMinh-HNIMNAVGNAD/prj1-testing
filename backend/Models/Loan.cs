namespace backend.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person? Person { get; set; }
        public decimal Amount { get; set; }
        public string LoanType { get; set; }
        public string? Description { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Unpaid";
        public decimal PaidAmount { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

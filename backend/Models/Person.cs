namespace backend.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNum { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Loan>? Loans { get; set; }
    }
}

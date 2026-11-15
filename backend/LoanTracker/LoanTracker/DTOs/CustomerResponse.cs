namespace LoanTracker.DTOs
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Nik { get; set; } = null!;
        public decimal Income { get; set; }
    }
}

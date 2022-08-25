namespace server.Models
{
    public class ExpenseToCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}

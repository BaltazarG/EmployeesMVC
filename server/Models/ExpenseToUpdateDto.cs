namespace server.Models
{
    public class ExpenseToUpdateDto
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}

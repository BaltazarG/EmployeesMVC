using server.Entities;
using server.Models;

namespace server.Services.Interfaces
{
    public interface IExpenseService
    {
        public ExpenseDto? GetExpense(int userId, int expenseId);
        public ICollection<ExpenseDto>? GetExpenses(int userId);
        public void UpdateExpense(int userId, int expenseId, ExpenseToUpdateDto expense);
        public void DeleteExpense(int userId, int expenseId);
        public void AddExpense(int userId, ExpenseToCreateDto expense);

    }
}

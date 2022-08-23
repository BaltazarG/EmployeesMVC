using server.Entities;
using server.Models;

namespace server.Services.Interfaces
{
    public interface IExpenseService
    {
        public ExpenseDto? GetExpense(int userId, int expenseId);

    }
}

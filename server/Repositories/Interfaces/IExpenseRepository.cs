using server.Entities;

namespace server.Repositories.Interfaces
{
    public interface IExpenseRepository : IRepository
    {
        public void AddExpense(int userId, Expense expense);
        public void UpdateExpense(int userId, int expenseId, Expense expense);
        public void DeleteExpense(int userId, int expenseId);
        public Expense? GetExpense(int userId, int expenseId);

    }
}

using server.Contexts;
using server.Entities;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class ExpenseRepository : Repository, IExpenseRepository
    {
        public ExpenseRepository(AppDbContext context) : base(context)
        {
        }

        public void AddExpense(int userId, Expense expense)
        {
            
        }

        public void DeleteExpense(int userId, int expenseId)
        {
            throw new NotImplementedException();
        }

        public Expense? GetExpense(int userId, int expenseId)
        {
            //return _context.Expenses?.FirstOrDefault(e => e.Id == expenseId);
            return _context.Expenses?.Where(e => e.Id == expenseId && e.User.Id == userId).FirstOrDefault();
        }

        public void UpdateExpense(int userId, int expenseId, Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}

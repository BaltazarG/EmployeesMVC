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
            if(expense != null)
            {
                _context.Expenses?.Add(expense);
                SaveChanges();
            }
            
        }

        public void DeleteExpense(int userId, int expenseId)
        {
            var expenseToRemove = GetExpense(userId, expenseId);

            if (expenseToRemove != null)
            {
                _context.Expenses?.Remove(expenseToRemove);
                SaveChanges();

            }

        }

        public Expense? GetExpense(int userId, int expenseId)
        {
            return _context.Expenses?.Where(e => e.Id == expenseId && e.User.Id == userId).FirstOrDefault();
        }

        public ICollection<Expense>? GetExpenses(int userId)
        {
            return _context.Expenses?.Where(e => e.User.Id == userId).ToList();
        }

        public void UpdateExpense(int userId, int expenseId, Expense expense)
        {
            var expenseToUpdate = GetExpense(userId, expenseId);

            if (expenseToUpdate != null)
            {
                expenseToUpdate.Description = expense.Description;
                expenseToUpdate.Amount = expense.Amount;
                SaveChanges();
            }
        }
    }
}

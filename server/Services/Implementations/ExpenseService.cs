using AutoMapper;
using server.Entities;
using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;


        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
                
        }

        public void AddExpense(int userId, ExpenseToCreateDto expense)
        {
            
            var expenseMapped = _mapper.Map<Expense>(expense);
            expenseMapped.UserId = userId;
            _expenseRepository.AddExpense(userId, expenseMapped);

        }

        public void DeleteExpense(int userId, int expenseId)
        {
            _expenseRepository.DeleteExpense(userId, expenseId);
        }

        public ExpenseDto? GetExpense(int userId, int expenseId)
        {
            var expenseToMap = _expenseRepository.GetExpense(userId, expenseId);
            var expense = _mapper.Map<ExpenseDto>(expenseToMap);

            return expense;
        }

        public ICollection<ExpenseDto>? GetExpenses(int userId)
        {
            var expensesToMap = _expenseRepository.GetExpenses(userId);
            var expenses = _mapper.Map<ICollection<ExpenseDto>>(expensesToMap);
            return expenses;
        }

        public void UpdateExpense(int userId, int expenseId, ExpenseToUpdateDto expense)
        {
            var expenseUpdated = _mapper.Map<Expense>(expense);
            _expenseRepository.UpdateExpense(userId, expenseId, expenseUpdated);
        }
    }
}

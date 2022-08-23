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

        public ExpenseDto? GetExpense(int userId, int expenseId)
        {
            var expenseToMap = _expenseRepository.GetExpense(userId, expenseId);
            var expense = _mapper.Map<ExpenseDto>(expenseToMap);

            return expense;
        }
    }
}

using AutoMapper;
using server.Entities;
using server.Models;

namespace server.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDto>();

        }
    }
}

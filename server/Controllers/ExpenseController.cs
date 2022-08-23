using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;
using System.Security.Claims;

namespace server.Controllers
{
    [Route("api/user/{userId}/Expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("{expenseId}")]
        public ActionResult<string> GetExpense(int userId, int expenseId)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized();
            }

            if (id != userId)
                return Forbid();


            var expense = _expenseService.GetExpense(userId, expenseId);

            if (expense == null)
                return NotFound();


            return Ok(expense);
        }
    }
}

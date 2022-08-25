using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
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

        [HttpGet()]
        public ActionResult<ICollection<ExpenseDto>> GetExpenses(int userId)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized();
            }

            if (id != userId)
                return Forbid();


            var expenses = _expenseService.GetExpenses(userId);

            if (expenses == null)
                return NotFound();


            return Ok(expenses);
        }


        [HttpGet("{expenseId}")]
        public ActionResult<ExpenseDto> GetExpense(int userId, int expenseId)
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

        [HttpPut("{expenseId}")]
        public ActionResult<ExpenseDto> UpdateExpense(int userId, int expenseId, ExpenseToUpdateDto expenseUpdated)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized();
            }

            if (id != userId)
                return Forbid();


            _expenseService.UpdateExpense(userId, expenseId, expenseUpdated);

          

            return NoContent();
        }

        [HttpDelete("{expenseId}")]
        public ActionResult DeleteExpense(int userId, int expenseId)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized();
            }

            if (id != userId)
                return Forbid();


            _expenseService.DeleteExpense(userId, expenseId);


            return NoContent();
        }

        [HttpPost()]
        public ActionResult DeleteExpense(int userId, ExpenseToCreateDto expense)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
            {
                return Unauthorized();
            }

            if (id != userId)
                return Forbid();


            _expenseService.AddExpense(userId, expense);


            return Ok();
        }
    }
}

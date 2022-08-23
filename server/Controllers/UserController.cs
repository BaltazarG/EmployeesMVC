using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Interfaces;
using System.Security.Claims;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPut("{id}")]
        public ActionResult<string> EditUser(int id, UserToUpdateDto userToUpdate)
        {
           
            if (userToUpdate == null)
                return BadRequest();



            var userExists = _userService.GetUser(id);

            if (userExists == null)
                return Conflict();

            _userService.UpdateUser(id, userToUpdate);

            return Ok(userToUpdate);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> RemoveUser(int id)
        {
            var userExists = _userService.GetUser(id);

            if (userExists == null)
                return NotFound();

            _userService.DeleteUser(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetUser(int id)
        {

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            if (id != userId)
                return Forbid();


            var user = _userService.GetUser(id);

            if (user == null)
                return NotFound();


            return Ok(user);
        }

    }
}

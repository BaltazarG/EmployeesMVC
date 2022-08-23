using Microsoft.AspNetCore.Mvc;
using server.Entities;
using server.Models;
using server.Services.Implementations;
using server.Services.Interfaces;


namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtGeneratorService _jwtGenerator;
        private readonly IUserService _userService;


        public AuthController(IAuthService authService, IJwtGeneratorService jwtGenerator, IUserService userService)
        {
            _authService = authService;
            _jwtGenerator = jwtGenerator;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Login(AuthDto authenticationRequestBody)
        {
           
            var user = ValidateCredentials(authenticationRequestBody);

            if (user is null) 
                return Unauthorized();


            string? tokenToReturn = _jwtGenerator.GenerateAuthToken(user);

            return Ok(tokenToReturn);
        }

        [HttpPost("signup")]
        public ActionResult<string> Signup(UserToCreateDto userToCreate)
        {
            if(userToCreate == null)
                return BadRequest();


            bool userExists = _authService.UserExists(userToCreate.Email);

            if (userExists)
                return Conflict();


            string? tokenToReturn = _userService.AddUser(userToCreate);

            return Ok(tokenToReturn);
        }
        private User? ValidateCredentials(AuthDto authParams)
        {
            return _authService.ValidateUser(authParams);
        }

        
    }
}

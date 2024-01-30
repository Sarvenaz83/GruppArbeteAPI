using Application.Commands.UserCommands.RegisterUser;
using Application.Queries.UserQueries.GetAllUsers;
using Application.Validators;
using Infrastructure.Repository.UserRepository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.WalletCommands;
using Application.Queries.UserQueries.LoginUser;
using Application.Commands.UserCommands.UpdateUser;
using Application.Queries.PurchaseHistoriesQueries;
using Application.Dtos.WalletDtos;
using Application.Dtos.UserDtos;


namespace API.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _userValidator;


        public UserController(IMediator mediator, IUserRepository userRepository, UserValidator userValidator)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] NewUserDto userDto)
        {
            var validatorResult = _userValidator.Validate(userDto);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            var user = await _mediator.Send(new RegisterUserCommand(userDto));

            return Ok(new { Message = "Register successful", user.UserId, user.UserName });
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(string username, string password)
        {
            var token = await _mediator.Send(new LoginUserQuery { Username = username, Password = password });
            if (token != null)
                return Ok(token);
            else
                return NotFound("Invalid username or password.");
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllUsersQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllPurchaseHistories")]
        [Authorize]
        public async Task<IActionResult> GetAllPurchaseHistoriesAsync()
        {
            try
            {
                var purchaseHistories = await _mediator.Send(new GetAllPurchaseHistoriesQuery());
                return Ok(purchaseHistories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{userId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                var deletedUser = await _userRepository.DeleteUserAsync(userId);

                if (deletedUser != null)
                {

                    return Ok(new { Message = "User deleted successfully", deletedUser.UserId, deletedUser.UserName });
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("wallet/{userId}")]
        [Authorize]
        public async Task<ActionResult<WalletDto>> UpdateWalletById([FromRoute] Guid userId, [FromBody] WalletDto walletDto)
        {
            var walletValidator = new WalletValidator();
            var validationResult = walletValidator.Validate(walletDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = new UpdateWalletByIdCommand(userId, walletDto);
            var updatedWallet = await _mediator.Send(command);
            return Ok(updatedWallet);
        }

        [HttpPut("update/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserByIdCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest("Mismatched User ID.");
            }

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(result);
        }
    }
}

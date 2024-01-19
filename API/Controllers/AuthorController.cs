using Application.Commands.AuthorCommands.CreateAuthor;
using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Dtos;
using Application.Queries.AuthorQueries.GetAllAuthor;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        internal readonly IMediator _mediator;
        internal readonly AuthorValidator _authorValidator;

        public AuthorController(IMediator mediator, AuthorValidator authorValidator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _authorValidator = authorValidator ?? throw new ArgumentNullException(nameof(authorValidator));
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllAuthorsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Create a new Author
        [HttpPost]
        [Route("CreateAuthor")]
        //[Authorize(policy: "Admin")]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto newAuthor)
        {

            try
            {
                return Ok(await _mediator.Send(new CreateAuthorCommand(newAuthor)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Update an Author
        [HttpPut]
        [Route("UpdateAuthor/{updatedAuthorId}")]
        //[Authorize(policy: "Admin")]
        public async Task<IActionResult> UpdateAuthor(Guid authorId, [FromBody] AuthorDto updatedAuthor)
        {
            var validatorResult = _authorValidator.Validate(updatedAuthor);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var command = new UpdateAuthorByIdCommand(authorId, updatedAuthor);
            try
            {
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound($"Author with ID {authorId} not found.");
                }
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred processing your request.");
            }
        }

    }
}

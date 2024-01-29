using Application.Commands.AuthorCommands.CreateAuthor;
using Application.Commands.AuthorCommands.DeleteAuthor;
using Application.Commands.AuthorCommands.UpdateAuthor;
using Application.Dtos.AuthorDtos;
using Application.Queries.AuthorQueries.GetAllAuthor;
using Application.Queries.AuthorQueries.GetAuthorByBook;
using Application.Validators;
using Infrastructure.Repository.AuthorRepository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        internal readonly IMediator _mediator;
        internal readonly IAuthorRepository _authorRepository;
        internal readonly AuthorValidator _authorValidator;

        public AuthorController(IMediator mediator, IAuthorRepository authorRepository, AuthorValidator authorValidator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
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
        [HttpGet]
        [Route("GetAuthorByBook/{bookTitle}")]
        public async Task<IActionResult> GetAuthorByBook(string bookTitle)
        {
            try
            {
                var result = await _mediator.Send(new GetAuthorByBookQuery(bookTitle));

                if (result != null)
                    return Ok(result);
                else
                    return NotFound($"Found no author {bookTitle} has written.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        //Create a new Author
        [HttpPost]
        [Route("CreateAuthor")]
        [Authorize(Roles = "Admin")]
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
        [Route("UpdateAuthor/{authorId}")]
        [Authorize(Roles = "Admin")]
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

        [HttpDelete]
        [Route("DeleteAuthor/{authorId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAuthor(Guid authorId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteAuthorByIdCommand(authorId)));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

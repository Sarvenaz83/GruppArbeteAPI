using Application.Commands.AuthorCommands.CreateAuthor;
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
            _mediator = mediator;
            _authorValidator = authorValidator;
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

    }
}

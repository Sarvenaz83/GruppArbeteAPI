using Application.Queries.AuthorQueries.GetAllAuthor;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;

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

    }
}

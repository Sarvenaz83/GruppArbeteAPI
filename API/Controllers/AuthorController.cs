using Application.Queries.Author.GetAllAutors;
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

        //GetAllAuthors from database
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

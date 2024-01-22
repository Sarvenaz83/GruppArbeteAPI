using Application.Commands.BookCommands.CreateBook;
using Application.Commands.BookCommands.DeleteBook;
using Application.Commands.BookCommands.UpdateBook;
using Application.Dtos;
using Application.Queries.BookQueries.GetAllBooks;
using Application.Queries.BookQueries.GetBookByAuthorName;
using Application.Queries.BookQueries.GetBookById;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BookController : Controller
    {
        internal readonly IMediator _mediator;
        internal readonly BookValidator _bookValidator;

        public BookController(IMediator mediator, BookValidator bookValidator)
        {
            _mediator = mediator;
            _bookValidator = bookValidator;
        }

        [HttpGet]
        [Route("GetBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            try
            {
                var result = await _mediator.Send(new GetBookByIdQuery(bookId));

                if (result != null)
                    return Ok(result);
                else
                    return NotFound($"Book with id {bookId} not found.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        [Route("GetBookByAuthorName/{authorName}")]
        public async Task<IActionResult> GetBookByAuthorName(string authorName)
        {
            try
            {
                var result = await _mediator.Send(new GetBookByAuthorNameQuery(authorName));

                if (result != null)
                    return Ok(result);
                else
                    return NotFound($"Found no books {authorName} has written.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBooksQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateNewBook")]
        public async Task<IActionResult> CreateNewBook([FromBody] BookDto newBook)
        {
            var validatorResult = _bookValidator.Validate(newBook);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new CreateBookCommand(newBook)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateBook/{bookId}")]
        //[Authorize(policy: "Admin")]
        public async Task<IActionResult> UpdateBook(Guid bookId, [FromBody] BookDto updateBook)
        {
            var validatorResult = _bookValidator.Validate(updateBook);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                var result = await _mediator.Send(new UpdateBookByIdCommand(bookId, updateBook));

                if (result == null)
                    return NotFound($"Book with ID {bookId} not found");
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred processing your request.");
            }
        }

        [HttpDelete]
        [Route("DeleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteBookCommand(bookId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

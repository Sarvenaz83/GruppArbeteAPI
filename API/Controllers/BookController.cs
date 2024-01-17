﻿using Application.Queries.BookQueries.GetAllBooks;
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
    }
}
using Application.Queries.ReceiptQueries.GetAllReceipts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReceiptController : Controller
    {
        internal readonly IMediator _mediator;

        public ReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllReceipts")]
        [Authorize]
        public async Task<IActionResult> GetAllReceipts()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllReceiptsQuery(Guid.NewGuid())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

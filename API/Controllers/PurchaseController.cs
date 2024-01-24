using Application.Queries.PurchaseDetailQueries.GetAllPurchaseDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PurchaseDetailController : Controller
    {
        internal readonly IMediator _mediator;

        public PurchaseDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllPurchaseDetails")]
        public async Task<IActionResult> GetAllPurchaseDetails()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllPurchaseDetailQuery(Guid.NewGuid())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

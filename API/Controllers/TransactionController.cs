using Application.Queries.PurchaseHistoriesQueries;
using Application.Queries.ReceiptQueries.GetAllReceipts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionController : Controller
    {
        internal readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
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

    }
}

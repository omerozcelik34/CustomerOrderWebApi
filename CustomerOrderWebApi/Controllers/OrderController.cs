using CustomerOrderWebApi.Features.Orders.Queries.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            // get all Orders
            var response = await mediator.Send(new GetAllOrdersQueryRequest());
            return Ok(response);
        }       
    }
}

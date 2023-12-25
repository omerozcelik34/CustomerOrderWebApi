using CustomerOrderWebApi.Features.Customers.Command.CreateCustomer;
using CustomerOrderWebApi.Features.Customers.Queries.GetAllCustomers;
using CustomerOrderWebApi.Features.Customers.Queries.GetCustomerById;
using CustomerOrderWebApi.Features.Customers.Queries.GetOrdersByCustomerId;
using CustomerOrderWebApi.Features.Orders.Command.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommandRequest request)
        {
            // create Customer.
            await mediator.Send(request);
            return Ok($"successful");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request)
        {            
            // create Order to Customer.
            await mediator.Send(request);
            return Ok($"successful");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            // get all customers.
            var response = await mediator.Send(new GetAllCustomersQueryRequest());
            return Ok(response);
        }

        [HttpGet("/Customer/GetOrdersByCustomerId/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            // get orders by CustomerId
            var query = new GetOrdersByCustomerIdQueryRequest { CustomerId = customerId };
            var response = await mediator.Send(query);
            if (response.Count == 0)
            {
                return NotFound($"Orders not found for customer with ID {customerId}");
            }
            return Ok(response);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            // get Customer by Id
            var query = new GetCustomerByIdQueryRequest { CustomerId = customerId };
            var response = await mediator.Send(query);
            return Ok(response);
        }      
    }
}

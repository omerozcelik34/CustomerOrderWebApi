using CustomerOrderWebApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQueryRequest, IList<GetOrdersByCustomerIdQueryResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetOrdersByCustomerIdQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // add default values.
            ApplicationDbContext.Seed(_dbContext);
        }
        public async Task<IList<GetOrdersByCustomerIdQueryResponse>> Handle(GetOrdersByCustomerIdQueryRequest request, CancellationToken cancellationToken)
        {
            // get orders by CustomerId
            var customer = await Task.Run(() => _dbContext.Customers.Include(o => o.Orders).FirstOrDefault(c => c.Id == request.CustomerId));

            var customerOrders = customer?.Orders?.ToList();
            if (customer == null || customerOrders == null)
            {
                // Customer not found or customer has no orders, return an empty list
                return new List<GetOrdersByCustomerIdQueryResponse>();
            }

            List<GetOrdersByCustomerIdQueryResponse> response = new();

            foreach (var order in customerOrders)
            {
                response.Add(new GetOrdersByCustomerIdQueryResponse
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    Address = order.Address,
                    Price = order.Price,
                    ProductName = order.ProductName,
                });
            }
            return response;
        }
    }
}

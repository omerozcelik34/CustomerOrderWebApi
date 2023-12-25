using CustomerOrderWebApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderWebApi.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, IList<GetAllOrdersQueryResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllOrdersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // add default values.
            ApplicationDbContext.Seed(_dbContext);
        }

        public async Task<IList<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            // get all Orders
            var orders = await _dbContext.Orders.ToListAsync();
            List<GetAllOrdersQueryResponse> response = new();

            foreach (var order in orders)

                response.Add(new GetAllOrdersQueryResponse
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    ProductName = order.ProductName,
                    Price = order.Price,
                    Address = order.Address
                });

            return response;
        }
    }
}

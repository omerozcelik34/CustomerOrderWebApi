using MediatR;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQueryRequest : IRequest<IList<GetOrdersByCustomerIdQueryResponse>>
    {
        public int CustomerId { get; set; }
    }
}

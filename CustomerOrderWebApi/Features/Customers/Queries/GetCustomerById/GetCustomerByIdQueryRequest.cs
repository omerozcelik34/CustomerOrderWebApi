using MediatR;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryRequest : IRequest<GetCustomerByIdQueryResponse>
    {
        public int CustomerId { get; set; }
    }
}

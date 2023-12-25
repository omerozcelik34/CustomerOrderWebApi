using MediatR;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryRequest : IRequest<IList<GetAllCustomersQueryResponse>>
    {
    }
}

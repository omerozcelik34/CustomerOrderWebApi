using MediatR;

namespace CustomerOrderWebApi.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryRequest : IRequest<IList<GetAllOrdersQueryResponse>>
    {
    }
}

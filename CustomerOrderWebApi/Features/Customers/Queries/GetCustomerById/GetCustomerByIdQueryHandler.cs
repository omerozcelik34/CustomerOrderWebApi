using CustomerOrderWebApi.Data;
using MediatR;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetCustomerByIdQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // added default values
            ApplicationDbContext.Seed(_dbContext);
        }
        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // get Customer by Id
            var customer = await Task.Run(() => _dbContext.Customers.FirstOrDefault(c => c.Id == request.CustomerId));

            GetCustomerByIdQueryResponse response = new GetCustomerByIdQueryResponse();
            if(customer != null)
            {
                response.Id = customer.Id;
                response.FirstName = customer.FirstName;
                response.LastName = customer.LastName;
            }

            return response;
        }
    }
}

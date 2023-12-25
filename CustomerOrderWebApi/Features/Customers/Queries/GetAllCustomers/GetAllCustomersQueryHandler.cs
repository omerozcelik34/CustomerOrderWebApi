using CustomerOrderWebApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderWebApi.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, IList<GetAllCustomersQueryResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllCustomersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // add default values.
            ApplicationDbContext.Seed(_dbContext);
        }
        public async Task<IList<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            // get all Customers
            var customers = await _dbContext.Customers.ToListAsync();
            List<GetAllCustomersQueryResponse> response = new();
            
            foreach (var customer in customers)
            
                response.Add(new GetAllCustomersQueryResponse
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                });
            
            return response;
        }
    }
}

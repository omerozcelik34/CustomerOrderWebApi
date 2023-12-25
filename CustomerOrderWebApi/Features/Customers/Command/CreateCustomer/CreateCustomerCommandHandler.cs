using CustomerOrderWebApi.Data;
using CustomerOrderWebApi.Models;
using MediatR;

namespace CustomerOrderWebApi.Features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateCustomerCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // add default values.
            ApplicationDbContext.Seed(_dbContext);
        }
        public Task Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            // create Customer
            Customer customer = new Customer();
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Id = _dbContext.Customers.Count() + 1;
            customer.Orders = null;
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();   
            return Task.CompletedTask;
        }
    }
}

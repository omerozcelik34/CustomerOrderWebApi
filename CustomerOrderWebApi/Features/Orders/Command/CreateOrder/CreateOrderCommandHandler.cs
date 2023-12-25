using CustomerOrderWebApi.Data;
using CustomerOrderWebApi.Models;
using MediatR;

namespace CustomerOrderWebApi.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            // add default values.
            ApplicationDbContext.Seed(_dbContext);
        }
        public Task Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            // create Order
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == request.CustomerId);
 
            Order order = new Order();
            order.Id = _dbContext.Orders.Count() + 1;
            order.CustomerId = request.CustomerId;
            order.ProductName = request.ProductName;
            order.Address = request.Address;
            order.Price = request.Price;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
